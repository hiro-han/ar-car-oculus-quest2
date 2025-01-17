﻿/*
© Siemens AG, 2017-2018
Author: Dr. Martin Bischoff (martin.bischoff@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using UnityEngine;
using System;
using System.Collections;

namespace RosSharp.RosBridgeClient
{
    [RequireComponent(typeof(RosConnector))]
    public abstract class UnityPublisher<T> : MonoBehaviour where T : Message
    {
        public string Topic;
        private string publicationId;

        private RosConnector rosConnector;
        protected bool initialized = false;

        protected virtual void Start()
        {
            try
            {
                rosConnector = GetComponent<RosConnector>();
                publicationId = rosConnector.RosSocket.Advertise<T>(Topic);
            } catch (Exception e)
            {
                // nop
            }  
        }

        protected void Publish(T message)
        {
            if (!rosConnector)
            {
                rosConnector = GetComponent<RosConnector>();
            }
            if (string.IsNullOrEmpty(publicationId)) {
                publicationId = rosConnector.RosSocket.Advertise<T>(Topic);
            }
            rosConnector.RosSocket.Publish(publicationId, message);
        }
    }
}