using System.Linq;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Couchbase.Linq.ChangeTracking;

namespace Couchbase.Linq
{
    /// <summary>
    /// Provides a single point of entry to a Couchbase bucket which makes it easier to compose
    /// and execute queries and to group togather changes which will be submitted back into the bucket.
    /// </summary>
    public interface IBucketContext : IBucketQueryable
    {
        /// <summary>
        /// Gets the configuration for the current <see cref="Cluster"/>.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        ClientConfiguration Configuration { get; }

        /// <summary>
        /// Queries the current <see cref="IBucket"/> for entities of type <see cref="T"/>. This is the target of
        /// the Linq query requires that the associated JSON document have a type property that is the same as <see cref="T"/>.
        /// </summary>
        /// <typeparam name="T">An entity or POCO representing the object graph of a JSON document.</typeparam>
        /// <returns></returns>
        IQueryable<T> Query<T>();

        /// <summary>
        /// Saves the specified document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document">The document.</param>
        void Save<T>(T document);

        /// <summary>
        /// Removes the specified document.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="document">The document.</param>
        void Remove<T>(T document);

        /// <summary>
        ///  If change tracking is enabled and the documents inherit from <see cref="DocumentBase"/> then
        ///  any changes will be submitted to the bucket.
        /// </summary>
        void SubmitChanges();

        /// <summary>
        /// Enables change tracking on documents inheriting from <see cref="DocumentBase"/>.
        /// </summary>
        void EnableChangeTracking();

        /// <summary>
        /// If change tracking is enabled, disables it and flushes any documents being tracked.
        /// </summary>
        void DisableChangeTracking();

        /// <summary>
        /// Gets the change tracker for tracking modifications of documents
        /// </summary>
        /// <value>
        /// The change tracker.
        /// </value>
        ChangeTracker ChangeTracker { get; }
    }
}
