﻿/*
 * Copyright 2015-2016 Mohawk College of Applied Arts and Technology
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
 * Date: 2016-11-3
 */
using Newtonsoft.Json;

namespace OpenIZ.Persistence.Diagnostics.Jira.Model
{

    /// <summary>
    /// Represents JIRA session information
    /// </summary>
    [JsonObject]
    public class JiraSessionInfo
    {

        /// <summary>
        /// Gets or sets the name of the session
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the value of the session
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }

    }
}