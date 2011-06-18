using System;
using System.Collections;
using System.Collections.Generic;
using FluentJdf.Resources;
using Infrastructure.Core.CodeContracts;

namespace FluentJdf.Encoding {
    /// <summary>
    /// A collection of transmission parts.
    /// </summary>
    public class TransmissionPartCollection : ITransmissionPartCollection {
        Dictionary<string, ITransmissionPart> transmissionParts = new Dictionary<string, ITransmissionPart>();

        /// <summary>
        /// Construct an empty collection.
        /// </summary>
        public TransmissionPartCollection() {}

        /// <summary>
        /// Construct a collection and put in the transmission parts
        /// from the <see cref="IEnumerable{ITransmissionPart}"/>
        /// </summary>
        /// <param name="transmissionParts"></param>
        public TransmissionPartCollection(IEnumerable<ITransmissionPart> transmissionParts) {
            ParameterCheck.ParameterRequired(transmissionParts, "transmissionParts");

            AddRange(transmissionParts);
        }

        /// <summary>
        /// Gets the transmission part with the given key.
        /// </summary>
        /// <returns></returns>
        public ITransmissionPart this[string id] {
            get { return transmissionParts[id]; }
        }

        #region ITransmissionPartCollection Members

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Add a new transmission part.
        /// </summary>
        /// <param name="transmissionPart"></param>
        /// <exception cref="ArgumentException">If a transmission part with the same id already exists in the collection.</exception>
        public void Add(ITransmissionPart transmissionPart) {
            ParameterCheck.ParameterRequired(transmissionPart, "transmissionPart");

            if (transmissionParts.ContainsKey(transmissionPart.Id)) {
                throw new ArgumentException(string.Format(Messages.TransmissionPartCollection_Add_TransmissionPartExists, transmissionPart.Id));
            }

            transmissionParts.Add(transmissionPart.Id, transmissionPart);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public IEnumerator<ITransmissionPart> GetEnumerator() {
            return transmissionParts.Values.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }


        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only. </exception>
        public void Clear() {
            transmissionParts.Clear();
        }

        /// <summary>
        /// Determines whether the collection contains an item with the same key
        /// as the given item.
        /// </summary>
        /// <returns>
        /// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
        /// </returns>
        /// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
        public bool Contains(ITransmissionPart item) {
            ParameterCheck.ParameterRequired(item, "item");

            return ContainsId(item.Id);
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting at a particular <see cref="T:System.Array"/> index.
        /// </summary>
        public void CopyTo(ITransmissionPart[] array, int arrayIndex) {
            transmissionParts.Values.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        /// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param><exception cref="T:System.NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</exception>
        public bool Remove(ITransmissionPart item) {
            ParameterCheck.ParameterRequired(item, "item");

            return transmissionParts.Remove(item.Id);
        }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </summary>
        /// <returns>
        /// The number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"/>.
        /// </returns>
        public int Count {
            get { return transmissionParts.Count; }
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.
        /// </summary>
        /// <returns>
        /// true if the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only; otherwise, false.
        /// </returns>
        public bool IsReadOnly {
            get { return false; }
        }

        #endregion

        /// <summary>
        /// Used internally to perform the dispose.
        /// </summary>
        /// <param name="isDisposing"></param>
        protected virtual void Dispose(bool isDisposing) {
            if (isDisposing && transmissionParts != null) {
                foreach (ITransmissionPart transmissionPart in transmissionParts.Values) {
                    transmissionPart.Dispose();
                }
                transmissionParts = null;
            }
        }

        /// <summary>
        /// Add a collection of transmission parts
        /// </summary>
        /// <param name="transmissionParts"></param>
        public void AddRange(IEnumerable<ITransmissionPart> transmissionParts) {
            ParameterCheck.ParameterRequired(transmissionParts, "transmissionParts");

            foreach (ITransmissionPart transmissionPart in transmissionParts) {
                Add(transmissionPart);
            }
        }

        /// <summary>
        /// Returns true if a transmission part with the 
        /// given id already exists in the collection.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool ContainsId(string id) {
            return transmissionParts.ContainsKey(id);
        }
    }
}