using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using Couchbase.Core;
using Couchbase.Core.Serialization;
using Couchbase.Linq.ChangeTracking;
using  Couchbase.Linq.Tests.Documents.ChangeTracking;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;


namespace Couchbase.Linq.Tests.ChangeTracking
{
    [TestFixture]
    public class ChangeTrackerTests
    {
        [Test]
        public void Test_Register()
        {
            var bucket = new Mock<IBucket>();
            var tracker = new ChangeTracker(bucket.Object);
            var schedule = new Schedule();
            tracker.Register(schedule);
            schedule.Day = 10;
            Assert.IsTrue(schedule.IsDirty);
        }

        [Test]
        public void When_Property_On_Poco_Is_Changed_It_Is_Added_ToChangedList()
        {
            var tracker = new ChangeTracker(new Mock<IBucket>().Object);
            var config = TestConfigurations.DefaultConfig();
            config.Serializer=() => new DefaultSerializer(new JsonSerializerSettings
            {
                Context = new StreamingContext(StreamingContextStates.Other, tracker)
            }, new JsonSerializerSettings());

            using (var cluster = new Cluster(config))
            {
                using (var bucket = cluster.OpenBucket("beer-sample"))
                {
                    var context = new BucketContext(bucket);
                    var query = (from s in context.Query<Schedule>()
                                select s).Take(2);

                    foreach (var schedule in query)
                    {
                        schedule.Day = 12;
                    }

                    Assert.AreEqual(2, tracker.GetChangeSet().Count);
                }
            }
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
