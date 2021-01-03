using System;
using Xunit;
using IIG.BinaryFlag;

namespace KPI_LAB2
{
    public class UnitTest : IDisposable
    {
        private MultipleBinaryFlag _MBF;
        private ulong SIZE = 5;

        public UnitTest()
        {
            _MBF = new MultipleBinaryFlag(SIZE, true);
        }

        public void Dispose()
        {
            _MBF = null;
        }

        private void SetAllClass()
        {
            for(ulong i = 0; i < SIZE; i++) _MBF.SetFlag(i);
        }

        private void ResetAllClass()
        {
            for (ulong i = 0; i < SIZE; i++) _MBF.ResetFlag(i);
        }

        [Theory]
        [InlineData(1, true, true)]
        [InlineData(1, false, true)]
        [InlineData(17179868704, true, true)]
        [InlineData(17179868704, false, true)]
        [InlineData(145, true, false)]
        [InlineData(145, false, false)]
        public void TestConstructor(ulong size, bool initState, bool isError)
        {
            var exceprion = Record.Exception(() => new MultipleBinaryFlag(size, initState));
            if (isError) Assert.NotNull(exceprion);
            else Assert.Null(exceprion);
        }

        [Fact]
        public void TestGetFlag()
        {
            // Test after init ->
            Assert.True(_MBF.GetFlag());
            ResetAllClass();
            // Test after change the whole state ->
            Assert.False(_MBF.GetFlag());
            SetAllClass();
            // Test after change the whole state ->
            Assert.True(_MBF.GetFlag());
            // Test after change the state partially ->
            _MBF.ResetFlag(0);
            Assert.False(_MBF.GetFlag());
            // Test after change the state partially ->
            _MBF.SetFlag(0);
            ResetAllClass();
            _MBF.SetFlag(0);
            Assert.False(_MBF.GetFlag());
        }


        [Fact]
        public void TestDispose()
        {
            _MBF.Dispose();
            Assert.Null(_MBF);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void TestSetAndResest(bool isReset)
        {
            var exception = Record.Exception(() => {
                if (isReset) _MBF.ResetFlag(SIZE + 1);
                else _MBF.SetFlag(SIZE + 1);
            });
            Assert.NotNull(exception);
        }
    }
}
