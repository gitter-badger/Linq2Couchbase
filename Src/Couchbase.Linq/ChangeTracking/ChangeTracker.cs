using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using Couchbase.Core;
using Couchbase.Linq.Metadata;

namespace Couchbase.Linq.ChangeTracking
{
    public class ChangeTracker
    {
        private readonly IBucket _bucket;
        private ConcurrentDictionary<DocumentMetadata, DocumentBase>_refs = new ConcurrentDictionary<DocumentMetadata, DocumentBase>();
        private volatile bool _enabled;
        private readonly object _syncLoc = new object();

        public ChangeTracker(IBucket bucket)
        {
            _bucket = bucket;
        }

        public void Register(INotifyPropertyChanged observable)
        {
            observable.PropertyChanged += observable_PropertyChanged;
        }

        void observable_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var document = sender as DocumentBase;
            if (document != null)
            {
                document.IsDirty = true;
                _refs.AddOrUpdate(document.MetaData, document, (m, d) => d);
            }
        }

        public void EnableChangeTracking()
        {
            lock (_syncLoc)
            {
                if (!_enabled)
                {
                    _refs.Clear();
                    _enabled = true;
                }
            }
        }

        public void DisableChangeTracking()
        {
            lock (_syncLoc)
            {
                if (_enabled)
                {
                    _refs.Clear();
                    _enabled = false;
                }
            }
        }

        internal IDictionary<DocumentMetadata, DocumentBase> GetChangeSet()
        {
            var changed = new Dictionary<DocumentMetadata, DocumentBase>(_refs.Count);
            foreach (var item in _refs)
            {
                changed.Add(item.Key, item.Value);
            }
            return changed;
        }
    }
}

#region [ License information          ]

/* ************************************************************
 *
 *    @author Couchbase <info@couchbase.com>
 *    @copyright 2015 Couchbase, Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 * ************************************************************/

#endregion
