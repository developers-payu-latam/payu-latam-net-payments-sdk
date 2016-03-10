// <copyright file="AbstractBuilder.cs" company="PayU Latam">
//    PayU Latam. All rights reserved.
// </copyright>
// <author>Jorge D. Porras</author>

namespace PayuNetSdk.PayU.Builders
{
    using PayuNetSdk.PayU.Messages;
    using System;

    /// <summary>
    /// Builder class base for build new objects of T.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class AbstractBuilder<T>
    {
        private T entity;

        protected AbstractRequest request;

        /// <summary>
        /// Initializes a new instance of the <see cref="AbstractBuilder{T}"/> class.
        /// </summary>
        /// <param name="request">The request.</param>
        public AbstractBuilder(AbstractRequest request)
        {
            this.entity = Activator.CreateInstance<T>();
            this.request = request;
            this.Build();
        }

        /// <summary>
        /// Gets the entity.
        /// </summary>
        /// <value>
        /// The entity.
        /// </value>
        public T Entity
        {
            get
            {
                return this.entity;
            }
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        public abstract void Build();
    }
}
