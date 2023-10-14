﻿using System;
using System.Runtime.InteropServices;

namespace HashCalculator
{
    internal class OfficialBlake2bp : AbsOfficialBlake2
    {
        [DllImport(DllName.Blake2, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr blake2bp_new();

        [DllImport(DllName.Blake2, CallingConvention = CallingConvention.Cdecl)]
        private static extern void blake2_delete_state(IntPtr statePtr);

        [DllImport(DllName.Blake2, CallingConvention = CallingConvention.Cdecl)]
        private static extern int blake2bp_init(IntPtr statePtr, ulong outlen);

        [DllImport(DllName.Blake2, CallingConvention = CallingConvention.Cdecl)]
        private static extern int blake2bp_update(IntPtr statePtr, byte[] input, ulong inlen);

        [DllImport(DllName.Blake2, CallingConvention = CallingConvention.Cdecl)]
        private static extern int blake2bp_update(IntPtr statePtr, ref byte input, ulong inlen);

        [DllImport(DllName.Blake2, CallingConvention = CallingConvention.Cdecl)]
        private static extern int blake2bp_final(IntPtr statePtr, byte[] output, ulong outlen);

        public override ulong MaxOutputSize => 64;

        public override string NamePrefix => "BLAKE2bp";

        public override AlgoType AlgoGroup => AlgoType.BLAKE2BP;

        public OfficialBlake2bp(ulong bitLength) : base(bitLength)
        {
        }

        public override IHashAlgoInfo NewInstance()
        {
            return new OfficialBlake2bp(this.bitLength);
        }

        public override void Blake2DeleteState(IntPtr statePtr)
        {
            blake2_delete_state(statePtr);
        }

        public override IntPtr Blake2New()
        {
            return blake2bp_new();
        }

        public override int Blake2Init(IntPtr statePtr, ulong outlen)
        {
            return blake2bp_init(statePtr, outlen);
        }

        public override int Blake2Update(IntPtr statePtr, byte[] input, ulong inlen)
        {
            return blake2bp_update(statePtr, input, inlen);
        }

        public override int Blake2Update(IntPtr statePtr, ref byte input, ulong inlen)
        {
            return blake2bp_update(statePtr, ref input, inlen);
        }

        public override int Blake2Final(IntPtr statePtr, byte[] output, ulong outlen)
        {
            return blake2bp_final(statePtr, output, outlen);
        }
    }
}
