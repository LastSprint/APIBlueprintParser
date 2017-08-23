﻿//
// ResourceActionTest.cs
// 23.08.2017
// Created by Kravchenkov Alexander
// sprintend@gmail.com
//

using System;
using NUnit.Framework;
using APIBlueprintParser.Parsers;
using APIBlueprintParser.Models;
using UriTemplate.Core;

namespace APIBlueprintTests {

	[TestFixture]
	public class ResourceActionTest {

		[Test]
		public void FullValidActionResourceTest() {
			
			// given
			var httpMethod = HttpMethod.Get;
			var template = "/samplePath/method";
			var identifier = "SampleResourceAction";
			var action = $"{identifier} [GET, {template}]{Environment.NewLine} " +
				$"This is sample action for unit test. Fuck off {Environment.NewLine}" +
				$"+ Attributes {Environment.NewLine}\t" +
				"+ la-la-la";
			var stream = Extensions.CreatFromString(action);

			// when
			var result = new ResourceActionParser(stream).ParseWithoutNestenNodes();

			// then

			Assert.AreEqual(result.Identifier, identifier);
			Assert.AreEqual(result.HttpMethod, httpMethod);
			Assert.AreEqual(result.Template.Template, template);

		}

		[Test]
		public void IvalidHttpMethodTest() {

			// given
			var template = "/samplePath/method";
			var identifier = "SampleResourceAction";
			var action = $"{identifier} [NuGet, {template}]{Environment.NewLine} " +
				$"This is sample action for unit test. Fuck off {Environment.NewLine}" +
				$"+ Attributes {Environment.NewLine}\t" +
				"+ la-la-la";
			var stream = Extensions.CreatFromString(action);

			// when then
			Assert.Throws<FormatException>(() => new ResourceActionParser(stream).ParseWithoutNestenNodes());
		}

		[Test]
		public void IvalidTemplateTest() {

			// given
			var template = "/samplePath/met hod";
			var identifier = "SampleResourceAction";
			var action = $"{identifier} [GET, {template}]{Environment.NewLine} " +
				$"This is sample action for unit test. Fuck off {Environment.NewLine}" +
				$"+ Attributes {Environment.NewLine}\t" +
				"+ la-la-la";
			var stream = Extensions.CreatFromString(action);

			// when then
			Assert.Throws<FormatException>(() => new ResourceActionParser(stream).ParseWithoutNestenNodes());
		}

	}
}
