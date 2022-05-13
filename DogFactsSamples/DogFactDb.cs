using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite;

namespace DogFactsSamples
{
    public class DogFactDb
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public DogFactDb()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(DogFactData).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(DogFactData)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<DogFactData>> GetItemsAsync()
        {
            return Database.Table<DogFactData>().ToListAsync();
        }

        public Task<DogFactData> GetItemAsync(int id)
        {
            return Database.Table<DogFactData>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(DogFactData item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> InsertList(IEnumerable<DogFactData> items)
        {
            return Database.InsertAllAsync(items);
        }

        public Task<int> DeleteItemAsync(DogFactData item)
        {
            return Database.DeleteAsync(item);
        }
        public Task<int> ClearAllAsync()
        {
            return Database.DeleteAllAsync<DogFactData>();
        }
    }
}