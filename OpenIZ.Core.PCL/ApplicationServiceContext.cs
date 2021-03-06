﻿/*
 * Copyright 2015-2017 Mohawk College of Applied Arts and Technology
 *
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
 * User: justi
 * Date: 2016-8-15
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenIZ.Core
{
    /// <summary>
    /// Application context
    /// </summary>
    public static class ApplicationServiceContext 
    {

        /// <summary>
        /// Gets or sets the current application service context
        /// </summary>
        public static IServiceProvider Current { get; set; }
        
        /// <summary>
        /// Type of application hosting this OpenIZ
        /// </summary>
        public static OpenIZHostType HostType { get; set; }
    }
}
