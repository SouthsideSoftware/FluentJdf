using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Core {

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class ReadOnlyDictionary<TKey, TValue> : IDictionary<TKey, TValue> {
        private IDictionary<TKey, TValue> _dictionary;

        /// <summary>
        /// 
        /// </summary>
        public ReadOnlyDictionary() {
            _dictionary = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dictionary"></param>
        public ReadOnlyDictionary(IDictionary<TKey, TValue> dictionary) {
            _dictionary = dictionary;
        }

        #region IDictionary<TKey,TValue> Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public void Add(TKey key, TValue value) {
            throw new NotSupportedException("This dictionary is read-only");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool ContainsKey(TKey key) {
            return _dictionary.ContainsKey(key);
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<TKey> Keys {
            get {
                return _dictionary.Keys;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool Remove(TKey key) {
            throw new NotSupportedException("This dictionary is read-only");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool TryGetValue(TKey key, out TValue value) {
            return _dictionary.TryGetValue(key, out value);
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<TValue> Values {
            get {
                return _dictionary.Values;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public TValue this[TKey key] {
            get {
                return _dictionary[key];
            }
            set {
                throw new NotSupportedException("This dictionary is read-only");
            }
        }

        #endregion

        #region ICollection<KeyValuePair<TKey,TValue>> Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void Add(KeyValuePair<TKey, TValue> item) {
            throw new NotSupportedException("This dictionary is read-only");
        }

        /// <summary>
        /// 
        /// </summary>
        public void Clear() {
            throw new NotSupportedException("This dictionary is read-only");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<TKey, TValue> item) {
            return _dictionary.Contains(item);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex) {
            _dictionary.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// 
        /// </summary>
        public int Count {
            get {
                return _dictionary.Count;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsReadOnly {
            get {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<TKey, TValue> item) {
            throw new NotSupportedException("This dictionary is read-only");
        }

        #endregion

        #region IEnumerable<KeyValuePair<TKey,TValue>> Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator() {
            return _dictionary.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            return (_dictionary as System.Collections.IEnumerable).GetEnumerator();
        }

        #endregion
    }
}
