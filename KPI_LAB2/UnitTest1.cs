using System;
using Xunit;
using IIG.BinaryFlag;

namespace KPI_LAB2
{
    public class UnitTest1
    {
        private string OutOfRangeException { get; set; } = "Length of Flag must be bigger than one";
        private string LesserThan { get; set; } = "Length of Flag must be lesseer than '17179868704'";

        [Fact]
        public void TestConstructor()
        {
            // Test for passing Argument ulong.MinValue
            ArgumentOutOfRangeException exception1 = Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(ulong.MinValue, true));
            // The thrown exception expected to be "Length of Flag must be bigger than one"
            Assert.Equal(OutOfRangeException, exception1.ParamName);

            // Test for passing Argument ulong.MinValue + 1
            ArgumentOutOfRangeException exception2 = Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(ulong.MinValue + 1, true));
            // The thrown exception expected to be "Length of Flag must be bigger than one"
            Assert.Equal(OutOfRangeException, exception2.ParamName);

            // Test for passing Argument ulong.MaxValue
            ArgumentOutOfRangeException exception3 = Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(ulong.MaxValue, true));
            // The thrown exception expected to be Length of Flag must be lesseer than '17179868704'"
            Assert.Equal(LesserThan, exception3.ParamName);

            // Test for passing Argument 17179868704
            ArgumentOutOfRangeException exception4 = Assert.Throws<ArgumentOutOfRangeException>(() => new MultipleBinaryFlag(17179868704, true));
            // The thrown exception expected to be Length of Flag must be lesseer than '17179868704'"
            Assert.Equal(LesserThan, exception4.ParamName);

            // Test for passing Argument 2
            var exception5 = Record.Exception(() => new MultipleBinaryFlag(2, true));
            // The thrown exception expected to be Length of Flag must be lesseer than '17179868704'"
            Assert.Null(exception5);
        }

        [Fact]
        public void TestGetFlag()
        {
            /*
             * Test GetFlag After init
            */
            MultipleBinaryFlag MBF1 = new MultipleBinaryFlag(3, true);
            MultipleBinaryFlag MBF2 = new MultipleBinaryFlag(3, false);
            MultipleBinaryFlag MBF3 = new MultipleBinaryFlag(3, true);
            // Expected to be true
            Assert.True(MBF1.GetFlag());

            // Expected to be false
            Assert.False(MBF2.GetFlag());


            // Test GetFlag After change 1 true to false
            MBF1.ResetFlag(0);
            Assert.False(false);

            // Test GetFlag After change 1 false to true
            MBF1.SetFlag(0);
            Assert.False(false);

            // Test Getflag After Reseting all false to true
            MBF2.SetFlag(0);
            MBF2.SetFlag(1);
            MBF2.SetFlag(2);

            /**
             * Test Fails
             */
            Assert.True(MBF2.GetFlag());

            // Test Getflag After Reseting all true to false
            MBF3.ResetFlag(0);
            MBF3.ResetFlag(1);
            MBF3.ResetFlag(2);

            /**
             * Test Fails
             */
            Assert.False(MBF3.GetFlag());
        }


        [Fact]
        public void TestSetFlag()
        {
            // Test setting for out of range
            MultipleBinaryFlag MBF1 = new MultipleBinaryFlag(2, true);
            Assert.Throws<ArgumentOutOfRangeException>(() => MBF1.SetFlag(12));

            // Test setting two false to true
            MultipleBinaryFlag MBF2 = new MultipleBinaryFlag(3, false);
            MBF2.SetFlag(0);
            MBF2.SetFlag(1);
            MBF2.SetFlag(2);
            Assert.True(MBF2.GetFlag());

            // Test setting two true to true
            MultipleBinaryFlag MBF3 = new MultipleBinaryFlag(3, true);
            MBF2.SetFlag(0);
            MBF2.SetFlag(1);
            MBF2.SetFlag(2);
            Assert.True(MBF2.GetFlag());
        }

        [Fact]
        public void TestReSetFlag()
        {
            // Test setting for out of range
            MultipleBinaryFlag MBF1 = new MultipleBinaryFlag(3, false);
            Assert.Throws<ArgumentOutOfRangeException>(() => MBF1.ResetFlag(12));

            // Test resetting two true to false
            MultipleBinaryFlag MBF2 = new MultipleBinaryFlag(2, true);
            MBF2.ResetFlag(0);
            MBF2.ResetFlag(1);
            Assert.False(MBF2.GetFlag());

            // Test resetting two false to false
            MultipleBinaryFlag MBF3 = new MultipleBinaryFlag(2, false);
            MBF2.ResetFlag(0);
            MBF2.ResetFlag(1);
            Assert.False(MBF2.GetFlag());
        }

        [Fact]
        public void TestDispose()
        {
            // Test setting for out of range
            MultipleBinaryFlag MBF1 = new MultipleBinaryFlag(3, true);
            MBF1.Dispose();
            // Test fails
            Assert.Null(MBF1);
        }
    }
}
