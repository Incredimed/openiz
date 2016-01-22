﻿using OpenIZ.Core.Model.Attributes;
using OpenIZ.Core.Model.Constants;
using OpenIZ.Core.Model.DataTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenIZ.Core.Model.Acts
{
    /// <summary>
    /// Represents an encounter a patient has with the health system
    /// </summary>
    [Serializable]
    [DataContract(Name = "PatientEncounter", Namespace = "http://openiz.org/model")]
    public class PatientEncounter : Act
    {

        // Disposition key
        private Guid? m_dischargeDispositionKey;
        // Disposition
        private Concept m_dischargeDisposition;

        /// <summary>
        /// Patient encounter ctor
        /// </summary>
        public PatientEncounter()
        {
            base.ClassConceptKey = ActClassKeys.Encounter;
        }

        /// <summary>
        /// Gets or sets the key of discharge disposition
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Browsable(false)]
        [DataMember(Name = "dischargeDisposition")]
        public Guid? DischargeDispositionKey
        {
            get { return this.m_dischargeDispositionKey; }
            set
            {
                this.m_dischargeDispositionKey = value;
                this.m_dischargeDisposition = null;
            }
        }

        /// <summary>
        /// Gets or sets the discharge disposition (how the patient left the encounter
        /// </summary>
        [IgnoreDataMember]
        [DelayLoad(nameof(DischargeDispositionKey))]
        public Concept DischargeDisposition
        {
            get
            {
                this.m_dischargeDisposition = base.DelayLoad(this.m_dischargeDispositionKey, this.m_dischargeDisposition);
                return this.m_dischargeDisposition;
            }
            set
            {
                this.m_dischargeDisposition = value;
                this.m_dischargeDispositionKey = value?.Key;
            }
        }
    }
}