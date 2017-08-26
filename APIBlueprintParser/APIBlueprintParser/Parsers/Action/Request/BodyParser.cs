﻿//
// BodyParser.cs
// 26.08.2017
// Created by Kravchenkov Alexander
// sprintend@gmail.com
//
//

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace APIBlueprintParser.Parsers.Action.Request {
    
    public class BodyParser: BaseParser {
        
        public struct Tokens {
            public static char[] EndOfSection = { '+', '-', '#' };
        }

        public BodyParser(StreamReader stream): base(stream) { }

        public string Parse() {
			var sectionCharArr = new List<char>();

            while (!base.streamReader.EndOfStream && !Tokens.EndOfSection.Contains((char)base.streamReader.Peek())) {
				sectionCharArr.Add((char)streamReader.Read());
			}

            var stringView = new String(sectionCharArr.ToArray()).Trim();


            if (stringView.Length == 0) {
                throw new FormatException("If body section declared then it must contains body");
            }

            return stringView;
        }
    }
}