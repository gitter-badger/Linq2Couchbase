using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using Couchbase.Linq.Metadata;

namespace Couchbase.Linq.ChangeTracking
{
    public abstract class DocumentBase : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        internal bool IsDirty { get; set; }

        protected void SetProperty<T>(ref T field, T value, [CallerMemberName] string name = "")
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                var handler = PropertyChanged;
                if (handler != null)
                {
                    // ReSharper disable once EventExceptionNotDocumented
                    handler(this, new PropertyChangedEventArgs(name));
                }
            }
        }

        [OnDeserialized]
        public void OnDeserialization(StreamingContext context)
        {
            var tracker = (ChangeTracker) context.Context;
            tracker.Register(this);
        }

        internal DocumentMetadata MetaData { get; set; }

        public object Clone()
        {
            return base.MemberwiseClone();
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
