﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Tensorflow;

namespace TensorFlowNET.UnitTest
{
    [TestClass]
    public class PlaceholderTest
    {
        [TestMethod]
        public void placeholder()
        {
            var x = tf.placeholder(tf.int32);
            var y = x * 3;

            Python.with<Session>(tf.Session(), sess =>
            {
                var result = sess.run(y, 
                    new FeedItem(x, 2));
                Assert.AreEqual((int)result, 6);
            });
        }
    }
}
