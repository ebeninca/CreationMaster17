using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace FifaLibrary.Frosty
{
  public sealed class FrostyProject
  {
    /*
      Project Versions:
        1 - Initial Version
        2 - (Unknown)
        3 - Assets can store multiple linked assets of CHUNK and RES type
        4 - (Unknown)
        5 - (Unknown)
        6 - New texture streaming changes (retroactively fixes old textures)
          - Stores mod details
        7 - Ebx now stored as objects rather than compressed byte streams
        8 - Chunk H32 now stored (retroactively calculate h32 for old projects)
        9 - Changed to a binary format, and added custom action handlers
        10 - TODO
        11 - Merging of defined res files (eg. ShaderBlockDepot)
        12 - Legacy files now use determinstic guids and added user data (retroactively fix old legacy files)
        13 - Merging of defined ebx files
        14 - H32 and FirstMip are now stored even if chunk was only added to bundles
    */

   /* private const uint FormatVersion = 14;

    private const ulong Magic = 0x00005954534F5246;

    public string DisplayName
    {
      get
      {
        if (filename == "")
          return "New Project.fbproject";

        FileInfo fi = new FileInfo(filename);
        return fi.Name;
      }
    }
    public string Filename
    {
      get => filename;
      set => filename = value;
    }
    public bool IsDirty => App.AssetManager.GetDirtyCount() != 0 || modSettings.IsDirty;

    public ModSettings ModSettings => modSettings;

    private string filename;
    private DateTime creationDate;
    private DateTime modifiedDate;
    public uint gameVersion;

    // mod export settings
    private ModSettings modSettings;

    public FrostyProject()
    {
      filename = "";
      creationDate = DateTime.Now;
      modifiedDate = DateTime.Now;
      gameVersion = 0;
      modSettings = new ModSettings { Author = Config.Get("ModAuthor", "") };
      //modSettings = new ModSettings {Author = Config.Get("ModSettings", "Author", "")};
      modSettings.ClearDirtyFlag();
    }

    public void Save(string overrideFilename = "", bool updateDirtyState = true)
    {
      string actualFilename = filename;
      if (!string.IsNullOrEmpty(overrideFilename))
        actualFilename = overrideFilename;

      modifiedDate = DateTime.Now;
      gameVersion = App.FileSystem.Head;

      FileInfo fi = new FileInfo(actualFilename);
      if (!fi.Directory.Exists)
      {
        // create output directory
        Directory.CreateDirectory(fi.DirectoryName);
      }

      // save to temporary file first
      string tempFilename = fi.FullName + ".tmp";

      using (NativeWriter writer = new NativeWriter(new FileStream(tempFilename, FileMode.Create)))
      {
        writer.Write(Magic);
        writer.Write(FormatVersion);
        writer.WriteNullTerminatedString(ProfilesLibrary.ProfileName);
        writer.Write(creationDate.Ticks);
        writer.Write(modifiedDate.Ticks);
        writer.Write(gameVersion);

        writer.WriteNullTerminatedString(modSettings.Title);
        writer.WriteNullTerminatedString(modSettings.Author);
        writer.WriteNullTerminatedString(modSettings.Category);
        writer.WriteNullTerminatedString(modSettings.Version);
        writer.WriteNullTerminatedString(modSettings.Description);

        if (modSettings.Icon != null && modSettings.Icon.Length != 0)
        {
          writer.Write(modSettings.Icon.Length);
          writer.Write(modSettings.Icon);
        }
        else
        {
          writer.Write(0);
        }

        for (int i = 0; i < 4; i++)
        {
          byte[] buf = modSettings.GetScreenshot(i);
          if (buf != null && buf.Length != 0)
          {
            writer.Write(buf.Length);
            writer.Write(buf);
          }
          else
          {
            writer.Write(0);
          }
        }

        // -----------------------------------------------------------------------------
        // added data
        // -----------------------------------------------------------------------------

        // @todo: superbundles
        writer.Write(0);

        // bundles
        long sizePosition = writer.Position;
        writer.Write(0xDEADBEEF);

        int count = 0;
        foreach (BundleEntry entry in App.AssetManager.EnumerateBundles(modifiedOnly: true))
        {
          if (entry.Added)
          {
            writer.WriteNullTerminatedString(entry.Name);
            writer.WriteNullTerminatedString(App.AssetManager.GetSuperBundle(entry.SuperBundleId).Name);
            writer.Write((int)entry.Type);
            count++;
          }
        }

        writer.Position = sizePosition;
        writer.Write(count);
        writer.Position = writer.Length;

        // ebx
        sizePosition = writer.Position;
        writer.Write(0xDEADBEEF);

        count = 0;
        foreach (EbxAssetEntry entry in App.AssetManager.EnumerateEbx(modifiedOnly: true))
        {
          if (entry.IsAdded)
          {
            writer.WriteNullTerminatedString(entry.Name);
            writer.Write(entry.Guid);
            count++;
          }
        }

        writer.Position = sizePosition;
        writer.Write(count);
        writer.Position = writer.Length;

        // res
        sizePosition = writer.Position;
        writer.Write(0xDEADBEEF);

        count = 0;
        foreach (ResAssetEntry entry in App.AssetManager.EnumerateRes(modifiedOnly: true))
        {
          if (entry.IsAdded)
          {
            writer.WriteNullTerminatedString(entry.Name);
            writer.Write(entry.ResRid);
            writer.Write(entry.ResType);
            writer.Write(entry.ResMeta);
            count++;
          }
        }

        writer.Position = sizePosition;
        writer.Write(count);
        writer.Position = writer.Length;

        // chunks
        sizePosition = writer.Position;
        writer.Write(0xDEADBEEF);

        count = 0;
        foreach (ChunkAssetEntry entry in App.AssetManager.EnumerateChunks(modifiedOnly: true))
        {
          if (entry.IsAdded)
          {
            writer.Write(entry.Id);
            writer.Write(entry.H32);
            count++;
          }
        }

        writer.Position = sizePosition;
        writer.Write(count);
        writer.Position = writer.Length;

        // -----------------------------------------------------------------------------
        // modified data
        // -----------------------------------------------------------------------------

        // ebx
        sizePosition = writer.Position;
        writer.Write(0xDEADBEEF);

        count = 0;
        foreach (EbxAssetEntry entry in App.AssetManager.EnumerateEbx(modifiedOnly: true, includeLinked: true))
        {
          writer.WriteNullTerminatedString(entry.Name);
          SaveLinkedAssets(entry, writer);

          // bundles the asset has been added to
          writer.Write(entry.AddedBundles.Count);
          foreach (int bid in entry.AddedBundles)
            writer.WriteNullTerminatedString(App.AssetManager.GetBundleEntry(bid).Name);

          // if the asset has been modified
          writer.Write(entry.HasModifiedData);
          if (entry.HasModifiedData)
          {
            // mark asset as only transient modified
            writer.Write(entry.ModifiedEntry.IsTransientModified);
            writer.WriteNullTerminatedString(entry.ModifiedEntry.UserData);

            ModifiedResource modifiedResource = entry.ModifiedEntry.DataObject as ModifiedResource;
            byte[] buf = null;
            bool bCustomHandler = modifiedResource != null;

            if (bCustomHandler)
            {
              // asset is using a custom handler
              buf = modifiedResource.Save();
            }
            else
            {
              // asset is using just regular data
              EbxAsset asset = entry.ModifiedEntry.DataObject as EbxAsset;
              using (EbxBaseWriter ebxWriter = EbxBaseWriter.CreateProjectWriter(new MemoryStream(), EbxWriteFlags.IncludeTransient))
              {
                ebxWriter.WriteAsset(asset);
                buf = ebxWriter.ToByteArray();
              }
            }

            writer.Write(bCustomHandler);
            writer.Write(buf.Length);
            writer.Write(buf);


            if (updateDirtyState)
              entry.ModifiedEntry.IsDirty = false;
          }

          if (updateDirtyState)
            entry.IsDirty = false;

          count++;
        }

        writer.Position = sizePosition;
        writer.Write(count);
        writer.Position = writer.Length;

        // res
        sizePosition = writer.Position;
        writer.Write(0xDEADBEEF);

        count = 0;
        foreach (ResAssetEntry entry in App.AssetManager.EnumerateRes(modifiedOnly: true))
        {
          writer.WriteNullTerminatedString(entry.Name);
          SaveLinkedAssets(entry, writer);

          // bundles the asset has been added to
          writer.Write(entry.AddedBundles.Count);
          foreach (int bid in entry.AddedBundles)
            writer.WriteNullTerminatedString(App.AssetManager.GetBundleEntry(bid).Name);

          // if the asset has been modified
          writer.Write(entry.HasModifiedData);
          if (entry.HasModifiedData)
          {
            writer.Write(entry.ModifiedEntry.Sha1);
            writer.Write(entry.ModifiedEntry.OriginalSize);
            if (entry.ModifiedEntry.ResMeta != null)
            {
              writer.Write(entry.ModifiedEntry.ResMeta.Length);
              writer.Write(entry.ModifiedEntry.ResMeta);
            }
            else
            {
              // no res meta
              writer.Write(0);
            }
            writer.WriteNullTerminatedString(entry.ModifiedEntry.UserData);

            byte[] buffer = entry.ModifiedEntry.Data;
            if (entry.ModifiedEntry.DataObject != null)
            {
              ModifiedResource md = entry.ModifiedEntry.DataObject as ModifiedResource;
              buffer = md.Save();
            }

            writer.Write(buffer.Length);
            writer.Write(buffer);
            if (updateDirtyState)
              entry.ModifiedEntry.IsDirty = false;
          }

          if (updateDirtyState)
            entry.IsDirty = false;

          count++;
        }

        writer.Position = sizePosition;
        writer.Write(count);
        writer.Position = writer.Length;

        // chunks
        sizePosition = writer.Position;
        writer.Write(0xDEADBEEF);

        count = 0;
        foreach (ChunkAssetEntry entry in App.AssetManager.EnumerateChunks(modifiedOnly: true))
        {
          writer.Write(entry.Id);

          // bundles the asset has been added to
          writer.Write(entry.AddedBundles.Count);
          foreach (int bid in entry.AddedBundles)
            writer.WriteNullTerminatedString(App.AssetManager.GetBundleEntry(bid).Name);

          writer.Write(entry.HasModifiedData ? entry.ModifiedEntry.FirstMip : entry.FirstMip);
          writer.Write(entry.HasModifiedData ? entry.ModifiedEntry.H32 : entry.H32);

          // if the asset has been modified
          writer.Write(entry.HasModifiedData);
          if (entry.HasModifiedData)
          {
            writer.Write(entry.ModifiedEntry.Sha1);
            writer.Write(entry.ModifiedEntry.LogicalOffset);
            writer.Write(entry.ModifiedEntry.LogicalSize);
            writer.Write(entry.ModifiedEntry.RangeStart);
            writer.Write(entry.ModifiedEntry.RangeEnd);
            writer.Write(entry.ModifiedEntry.AddToChunkBundle);
            writer.WriteNullTerminatedString(entry.ModifiedEntry.UserData);

            writer.Write(entry.ModifiedEntry.Data.Length);
            writer.Write(entry.ModifiedEntry.Data);
            if (updateDirtyState)
              entry.ModifiedEntry.IsDirty = false;
          }

          if (updateDirtyState)
            entry.IsDirty = false;

          count++;
        }

        writer.Position = sizePosition;
        writer.Write(count);
        writer.Position = writer.Length;

        // custom actions
        sizePosition = writer.Position;
        writer.Write(0xDEADBEEF);

        count = 0;
        ILegacyCustomActionHandler legacyHandler = new LegacyCustomActionHandler();
        legacyHandler.SaveToProject(writer);

        writer.Position = sizePosition;
        writer.Write(1);
        writer.Position = writer.Length;

        if (updateDirtyState)
          modSettings.ClearDirtyFlag();
      }

      if (File.Exists(tempFilename))
      {
        bool isValid = false;

        // check project file to ensure it saved correctly
        using (FileStream fs = new FileStream(tempFilename, FileMode.Open, FileAccess.Read))
        {
          if (fs.Length > 0)
          {
            isValid = true;
          }
        }

        if (isValid)
        {
          // replace existing project
          File.Delete(fi.FullName);
          File.Move(tempFilename, fi.FullName);
        }
      }
    }

    public ModSettings GetModSettings()
    {
      return modSettings;
    }

    public static void SaveLinkedAssets(AssetEntry entry, NativeWriter writer)
    {
      writer.Write(entry.LinkedAssets.Count);
      foreach (AssetEntry linkedEntry in entry.LinkedAssets)
      {
        writer.WriteNullTerminatedString(linkedEntry.AssetType);
        if (linkedEntry is ChunkAssetEntry assetEntry)
          writer.Write(assetEntry.Id);
        else
          writer.WriteNullTerminatedString(linkedEntry.Name);
      }
    }*/
  }
}
