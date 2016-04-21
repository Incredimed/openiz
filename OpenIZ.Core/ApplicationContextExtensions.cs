﻿/*
 * Copyright 2016-2016 Mohawk College of Applied Arts and Technology
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: fyfej
 * Date: 2016-3-8
 */
using MARC.HI.EHRS.SVC.Core;
using MARC.HI.EHRS.SVC.Core.Services;
using OpenIZ.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIZ.Core
{
    /// <summary>
    /// Application context extensions
    /// </summary>
    public static class ApplicationContextExtensions
    {

        /// <summary>
        /// Get locale
        /// </summary>
        public static String GetLocaleString(this ApplicationContext me, String stringId)
        {
            var locale = me.GetService<ILocalizationService>();
            if (locale == null)
                return stringId;
            else
                return locale.GetString(stringId);
        }

        /// <summary>
        /// Get the concept service
        /// </summary>
        public static IConceptService GetConceptService(this ApplicationContext me)
        {
            return me.GetService<IConceptService>();
        }

        /// <summary>
        /// Get application provider service
        /// </summary>
        public static IApplicationIdentityProviderService GetApplicationProviderService(this ApplicationContext me)
        {
            return me.GetService<IApplicationIdentityProviderService>();
        }
    }
}