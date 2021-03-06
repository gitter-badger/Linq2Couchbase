Linq2Couchbase
==================

The official Language Integrated Query (LINQ) provider for querying Couchbase Server 4.0 with [N1QL](http://developer.couchbase.com/documentation/server/4.0/n1ql/n1ql-intro/data-access-using-n1ql.html) using the Couchbase .NET SDK. The goal of Linq2Couchbase is to create a lightweight ORM/ODM for querying Couchbase Buckets using LINQ as the lingua-franca between your application and Couchbase Server 4.0 using N1QL, a SQL-like query language for JSON documents. It also provides a write API for performing CRUD operations on JSON documents.

##Getting started##
The Linq2Couchbase project has the following dependencies:

- Couchbase Server 4.0 or greater with the query service enabled on at least one node
- Couchbase .NET SDK 2.2.0 or greater
- Common.Logging 3.3.0 or greater
- Common.Logging.Core 3.3.0 or greater
- JSON.NET 7.0.1 or greater
- re-linq 1.15.15.0 (re-linq 2.0 is not currently supported!)

If you are using NuGet, then the dependencies (other than Couchbase server) will be installed for you via the package manager. 

###Installing Couchbase Server###
For a single instance of Couchbase server running on localhost, you can download one [here](http://www.couchbase.com/nosql-databases/downloads) (make sure it's 4.0). If you would like to create a cluster, the easiest way is by using the Vagrant scripts for provisioning clusters can be found [here](https://github.com/couchbaselabs/vagrants). Additionally, Docker scripts can be found [here](https://hub.docker.com/r/couchbase/server/). Following the directions on each respective link for installation information.

###Installing the package using NuGet###
Once you have a Couchbase Server 4.0 instance or cluster setup, open Visual Studio 13 or greater or [MonoDevelop](http://www.monodevelop.com/) and create an MVC Web Application. Open the NuGet Package Manager and search for "Couchbase Linq" or type the following into the Package Manager console:

    Install-Package Linq2Couchbase 

NuGet will install the package and all dependencies. Once you have the resolved the dependencies, you will initialize a ClusterHelper object which will manage the bucket resources needed by the Linq provider.

##Developer Guide##

- [The BucketContext: how to use with ASP.NET and Owin/Katana applications](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/bucket-context.md)
- [Mapping JSON fields to POCO properties](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/poco-mapping.md)
- [Mapping JSON documents to POCOs with DocumentFilters](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/document-filters.md)
- [Controlling output with Select](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/simple-select.md)
- [Filtering with Where](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/where-clause.md)
- [Sorting and Paging Results](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/sorting-take-limit.md)
- [String Handling](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/string-handling.md)
- [Math Functions](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/math-functions.md)
- [Date Handling](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/date-handling.md)
- [Array Filtering, Projections, and Sorting](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/array-filtering-projections.md)
- [Grouping and Aggregation](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/grouping-aggregation.md)
- [The UseKeys Method](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/use-keys.md)
- [JOINing Documents](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/joins.md)
- [NESTing Documents](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/nest.md)
- [UNNESTing Documents](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/unnest.md)
- [Any and All](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/any-all.md)
- [Testing For NULL And MISSING Attributes](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/null-missing-valued.md)
- [The META Keyword](https://github.com/couchbaselabs/Linq2Couchbase/blob/master/docs/meta-keyword.md)

##Building From Source##

The 1.0 release of Linq2Couchbase uses the NuGet package manager for handling dependencies.  However, the release currently in development is making use of some Couchbase SDK features that are not yet released.  Therefore, if working with the latest code the Couchbase SDK must be downloaded separately.

You may clone the SDK repository from https://github.com/couchbase/couchbase-net-client.  This repository should be placed beside the Linq2Couchbase repository, so your folder structure looks like this:

    <somepath>/couchbase-net-client
    <somepath>/Linq2Couchbase

Make sure you have the master branch of the SDK.  Then compile the couchbase-net-client solution in the Debug configuration.  This will create the libraries needed for Linq2Couchcbase to compile.

This will be changed to use NuGet once the new SDK changes have been released, and before the next version of Linq2Couchbase is available.


##Project management##

The jira project is [here](http://issues.couchbase.com/browse/LINQ) - you can file bugs, propose features or get an idea for the roadmap there. List of supported and proposed N1QL features can be found [here](https://docs.google.com/document/d/1hPNZ-qTKpVzQsFwg_1uUueltzNL1wA75L5F-hYF92Cw/edit?usp=sharing). 

##Contributors##
Linq2Couchbase is an open source project and community contributions are welcome whether they be pull-requests, feedback or filing bug tickets or feature requests. We appreciate any contribution no matter how bug or small! If you do decide to contribute, please browse the Jira project and ensure that that feature or issue hasn't already been documented. If you want to work on a feature, bug or whatever please create or select a ticket and set the status to "in-progress".


