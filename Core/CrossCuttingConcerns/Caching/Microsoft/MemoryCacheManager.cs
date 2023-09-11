using Core.Utilities.IoC;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Caching.Microsoft
{
    public class MemoryCacheManager : ICacheManager
    {

        //Adapter Pattern
        IMemoryCache _memoryCache;

        public MemoryCacheManager()
        {
            _memoryCache = ServiceTool.ServiceProvider.GetService<IMemoryCache>();

        }
        public void Add(string key, object value, int duration)
        {

            _memoryCache.Set(key, value, TimeSpan.FromMinutes(duration));
            //ne kadar süre verirsek(duration) o kadar süre cache'de kalacak
        }

        public T Get<T>(string key)
            //cache'den belli bir türdeki veriyi getirir
        {
            return _memoryCache.Get<T>(key);
        }

        public object Get(string key)
            //cache'den veriyi getirir ama dönecek tür object olduğu için tür dönüşümü yapılması gerekir
        {
            return _memoryCache.Get(key);


        }

        public bool IsAdd(string key)
            //belirli bir anahtar değeri cache'de var mı diye kontrol eder. varsa true yoksa false döner. (out _) ifadesi, değerin ne olduğunu döndürme sadece varlığını kontrol et demek.
        {
            return _memoryCache.TryGetValue(key, out _);
        }

        public void Remove(string key) 
            //cache'deki veriyi siler
        {
            _memoryCache.Remove(key);
        }

        public void RemoveByPattern(string pattern)
            //verdiğimiz bir patterne göre çalışma anında cacheden silme işlemini yapar. örnek>> [CacheRemoveAspect("ICarService.Get)")]
        {
            var cacheEntriesCollectionDefinition = typeof(MemoryCache).GetProperty
                ("EntriesCollection", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);//
            var cacheEntriesCollection = cacheEntriesCollectionDefinition.GetValue(_memoryCache) as dynamic;
            List<ICacheEntry> cacheCollectionValues = new List<ICacheEntry>();//ÖNBELLEK GİRDİLERİ LİSTESİ

            foreach (var cacheItem in cacheEntriesCollection)//cacheEntriesCollection tarıyor
            {
                ICacheEntry cacheItemValue = cacheItem.GetType().GetProperty("Value").GetValue(cacheItem, null);
                cacheCollectionValues.Add(cacheItemValue);//cacheEntriesCollections ların değerini value alıyor cacheIemValue olarak erişiyoruz
            }

            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);

            //verilen patterne regex oluşturuyoruz
            var keysToRemove = cacheCollectionValues.Where(d => regex.IsMatch(d.Key.ToString())).Select(d => d.Key).ToList();
            //cacheCollectionsValues keylere atıyor
            foreach (var key in keysToRemove)
            {
                _memoryCache.Remove(key);
            }
            //son olarak keylerle önbellek girdileri temizleniyor
        }
    }
}
