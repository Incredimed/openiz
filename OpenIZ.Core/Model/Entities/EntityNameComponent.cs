﻿using OpenIZ.Core.Model.Attributes;
using OpenIZ.Core.Model.DataTypes;
using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace OpenIZ.Core.Model.Entities
{
    /// <summary>
    /// Represents a name component which is bound to a name
    /// </summary>
    [Serializable]
    [DataContract(Namespace = "http://openiz.org/model", Name = "EntityNameComponent")]
    public class EntityNameComponent : GenericComponentValues<EntityName>
    {

        // Id of the algorithm used to generate phonetic code
        private Guid m_phoneticAlgorithmId;
        // Algorithm used to generate the code
        [NonSerialized]
        private PhoneticAlgorithm m_phoneticAlgorithm;

        /// <summary>
        /// Gets or sets the value of the name component
        /// </summary>
        [DataMember(Name = "value")]
        public String Value { get; set; }

        /// <summary>
        /// Gets or sets the phonetic code of the reference term
        /// </summary>
        [DataMember(Name = "phoneticCode")]
        public String PhoneticCode { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the phonetic code
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DataMember(Name = "phoneticAlgorithmRef")]
        public Guid PhoneticAlgorithmKey
        {
            get { return this.m_phoneticAlgorithmId; }
            set
            {
                this.m_phoneticAlgorithmId = value;
                this.m_phoneticAlgorithm = null;
            }
        }

        /// <summary>
        /// Gets or sets the phonetic algorithm
        /// </summary>
        [DelayLoad]
        [IgnoreDataMember]
        public PhoneticAlgorithm PhoneticAlgorithm
        {
            get
            {
                this.m_phoneticAlgorithm = base.DelayLoad(this.m_phoneticAlgorithmId, this.m_phoneticAlgorithm);
                return this.m_phoneticAlgorithm;
            }
            set
            {
                this.m_phoneticAlgorithm = value;
                if (value == null)
                    this.m_phoneticAlgorithmId = Guid.Empty;
                else
                    this.m_phoneticAlgorithmId = value.Key;
            }
        }


    }
}