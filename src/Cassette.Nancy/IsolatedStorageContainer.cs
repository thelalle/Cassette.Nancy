using System.IO.IsolatedStorage;
using Cassette.Utilities;

namespace Cassette.Nancy {
    /// <summary>
    /// Provides the isolated storage used by Cassette.
    /// Storage is only created on demand.
    /// </summary>
    internal static class IsolatedStorageContainer {
        private static readonly DisposableLazy<IsolatedStorageFile> lazyStorage = new DisposableLazy<IsolatedStorageFile>(() => CreateIsolatedStorage());

        private static IsolatedStorageFile CreateIsolatedStorage() {
            return IsolatedStorageFile.GetMachineStoreForAssembly();
        }

        public static IsolatedStorageFile IsolatedStorageFile {
            get { return lazyStorage.Value; }
        }

        public static void Dispose() {
            lazyStorage.Dispose();
        }
    }
}