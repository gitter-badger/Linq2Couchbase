﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Couchbase.Core.Serialization;
using Couchbase.Linq.QueryGeneration.MemberNameResolvers;
using Newtonsoft.Json.Serialization;
using Remotion.Linq.Clauses.Expressions;

namespace Couchbase.Linq.QueryGeneration
{
    /// <summary>
    /// Used to pass query generation context between various classes
    /// </summary>
    internal class N1QlQueryGenerationContext
    {

        public N1QlExtentNameProvider ExtentNameProvider { get; set; }
        public IMemberNameResolver MemberNameResolver { get; set; }
        public IMethodCallTranslatorProvider MethodCallTranslatorProvider { get; set; }
        public ParameterAggregator ParameterAggregator { get; set; }
        public ITypeSerializer Serializer { get; set; }

        /// <summary>
        /// Stores a reference to the current grouping subquery
        /// </summary>
        public QuerySourceReferenceExpression GroupingQuerySource { get; set; }

        public N1QlQueryGenerationContext()
        {
            ExtentNameProvider = new N1QlExtentNameProvider();
            ParameterAggregator = new ParameterAggregator();
        } 
    }
}
