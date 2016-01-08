﻿using MARC.HI.EHRS.SVC.Core;
using MARC.HI.EHRS.SVC.Core.Data;
using MARC.HI.EHRS.SVC.Core.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIZ.Core.Model.Security
{
    /// <summary>
    /// Security user represents a user for the purpose of security 
    /// </summary>
    public class SecurityUser : SecurityEntity
    {

        // Roles
        private List<SecurityRole> m_roles;
        // The updated by id
        private Guid? m_updatedById;
        // The updated by user
        private SecurityUser m_updatedBy;

        /// <summary>
        /// Gets or sets the email address of the user
        /// </summary>
        public String Email { get; set; }
        /// <summary>
        /// Gets or sets whether the email address is confirmed
        /// </summary>
        public Boolean EmailConfirmed { get; set; }
        /// <summary>
        /// Gets or sets the number of invalid login attempts by the user
        /// </summary>
        public Int32 InvalidLoginAttempts { get; set; }
        /// <summary>
        /// Gets or sets whether the account is locked out
        /// </summary>
        public Boolean LockoutEnabled { get; set; }
        /// <summary>
        /// Gets or sets whether the password hash is enabled
        /// </summary>
        public String PasswordHash { get; set; }
        /// <summary>
        /// Gets or sets whether the security has is enabled
        /// </summary>
        public String SecurityHash { get; set; }
        /// <summary>
        /// Gets or sets whether two factor authentication is required
        /// </summary>
        public Boolean TwoFactorEnabled { get; set; }
        /// <summary>
        /// Gets or sets the logical user name ofthe user
        /// </summary>
        public String UserName { get; set; }
        /// <summary>
        /// Gets or sets the binary representation of the user's photo
        /// </summary>
        public byte[] UserPhoto { get; set; }
        /// <summary>
        /// Represents roles
        /// </summary>
        public List<SecurityRole> Roles {
            get
            {
                if(this.m_roles == null)
                {
                    var dataLayer = ApplicationContext.Current.GetService<IDataPersistenceService<SecurityRole>>();
                    this.m_roles = dataLayer.Query(r => r.Users.Any(u => u.Key == this.Key), null).ToList();
                }
                return this.m_roles;
            }
        }
        /// <summary>
        /// Updated time
        /// </summary>
        public DateTimeOffset? UpdatedTime { get; set; }
        /// <summary>
        /// Gets or sets the user that updated this base data
        /// </summary>
        public SecurityUser UpdatedBy
        {
            get
            {
                if (this.m_updatedById.HasValue && this.m_updatedById == null)
                {
                    var dataLayer = ApplicationContext.Current.GetService<IDataPersistenceService<SecurityUser>>();
                    this.m_updatedBy = dataLayer.Get(new Identifier<Guid>(this.m_updatedById.Value), null, true);
                }
                return this.m_updatedBy;
            }
            set
            {
                if (value == null)
                {
                    this.m_updatedBy = null;
                    this.m_updatedById = null;
                }
                else
                {
                    this.m_updatedBy = value;
                    this.m_updatedById = value.Key;
                }
            }
        }

        /// <summary>
        /// Gets or sets the created by identifier
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Guid? UpdatedById
        {
            get { return this.m_updatedById; }
            set
            {
                if (this.m_updatedById != value)
                    this.m_updatedBy = null;
                this.m_updatedById = value;
            }
        }

    }
}