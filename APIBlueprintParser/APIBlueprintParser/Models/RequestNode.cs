﻿//
// RequestNode.cs
// 21.08.2017
// Created by Kravchenkov Alexander
// sprintend@gmail.com
//
//

namespace APIBlueprintParser.Models {

    public enum BodyType {
        Json
    }

    public class RequestNode {

        public BodyType BodyType { get; }

        public string Body { get; }

        public RequestNode(BodyType bodyType, string body) {
            this.BodyType = bodyType;
            this.Body = body;
        }
    }
}
