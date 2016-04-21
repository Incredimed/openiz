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
 * Date: 2016-4-19
 */
using OpenIZ.Core.Model.Roles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OpenIZ.Core.Services
{
    /// <summary>
    /// Represents the patient repository service. This service is responsible
    /// for ensuring that patient roles in the IMS database are in a consistent 
    /// state.
    /// </summary>
    public interface IPatientRepositoryService
    {


        /// <summary>
        /// Inserts the given patient
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        Patient Insert(Patient p);

        /// <summary>
        /// Updates the given patient only if they already exist
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        Patient Save(Patient p);

        /// <summary>
        /// Obsoletes the given patient
        /// </summary>
        Patient Obsolete(Guid key);

        /// <summary>
        /// Merges two patients together
        /// </summary>
        /// <param name="survivor">The surviving patient record</param>
        /// <param name="victim">The victim patient record</param>
        /// <returns>A new version of patient <paramref name="a"/> representing the merge</returns>
        Patient Merge(Patient survivor, Patient victim);

        /// <summary>
        /// Un-merges two patients from each other
        /// </summary>
        /// <param name="patient">The patient which is to be un-merged</param>
        /// <param name="versionKey">The version of patient P where the split should occur</param>
        /// <returns>A new patient representing the split record</returns>
        Patient UnMerge(Patient patient, Guid versionKey);

        /// <summary>
        /// Searches the patient service for the specified patient matching the 
        /// given predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        IEnumerable<Patient> Search(Expression<Func<Patient, bool>> predicate);

    }
}