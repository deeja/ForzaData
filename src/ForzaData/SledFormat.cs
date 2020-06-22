﻿using static ForzaData.PacketParse;

namespace ForzaData
{
    /// <summary>
    ///  Sled format    <iIfffffffffffffffffffffffffffffffffffffffffffffffffffiiiii'
    /// </summary>
    public static class SledFormat
    {
        public static bool IsRaceOn(this byte[] bytes) { return GetSingle(bytes, 0) > 0; }
        public static uint TimestampMs(this byte[] bytes) { return GetUInt32(bytes, 4); }
        public static float EngineMaxRpm(this byte[] bytes) { return GetSingle(bytes, 8); }
        public static float EngineIdleRpm(this byte[] bytes) { return GetSingle(bytes, 12); }
        public static float CurrentEngineRpm(this byte[] bytes) { return GetSingle(bytes, 16); }
        public static float AccelerationX(this byte[] bytes) { return GetSingle(bytes, 20); }
        public static float AccelerationY(this byte[] bytes) { return GetSingle(bytes, 24); }
        public static float AccelerationZ(this byte[] bytes) { return GetSingle(bytes, 28); }
        public static float VelocityX(this byte[] bytes) { return GetSingle(bytes, 32); }
        public static float VelocityY(this byte[] bytes) { return GetSingle(bytes, 36); }
        public static float VelocityZ(this byte[] bytes) { return GetSingle(bytes, 40); }
        public static float AngularVelocityX(this byte[] bytes) { return GetSingle(bytes, 44); }
        public static float AngularVelocityY(this byte[] bytes) { return GetSingle(bytes, 48); }
        public static float AngularVelocityZ(this byte[] bytes) { return GetSingle(bytes, 52); }
        public static float Yaw(this byte[] bytes) { return GetSingle(bytes, 56); }
        public static float Pitch(this byte[] bytes) { return GetSingle(bytes, 60); }
        public static float Roll(this byte[] bytes) { return GetSingle(bytes, 64); }
        public static float NormSuspensionTravelFl(this byte[] bytes) { return GetSingle(bytes, 68); }
        public static float NormSuspensionTravelFr(this byte[] bytes) { return GetSingle(bytes, 72); }
        public static float NormSuspensionTravelRl(this byte[] bytes) { return GetSingle(bytes, 76); }
        public static float NormSuspensionTravelRr(this byte[] bytes) { return GetSingle(bytes, 80); }
        public static float TireSlipRatioFl(this byte[] bytes) { return GetSingle(bytes, 84); }
        public static float TireSlipRatioFr(this byte[] bytes) { return GetSingle(bytes, 88); }
        public static float TireSlipRatioRl(this byte[] bytes) { return GetSingle(bytes, 92); }
        public static float TireSlipRatioRr(this byte[] bytes) { return GetSingle(bytes, 96); }
        public static float WheelRotationSpeedFl(this byte[] bytes) { return GetSingle(bytes, 100); }
        public static float WheelRotationSpeedFr(this byte[] bytes) { return GetSingle(bytes, 104); }
        public static float WheelRotationSpeedRl(this byte[] bytes) { return GetSingle(bytes, 108); }
        public static float WheelRotationSpeedRr(this byte[] bytes) { return GetSingle(bytes, 112); }
        public static float WheelOnRumbleStripFl(this byte[] bytes) { return GetSingle(bytes, 116); }
        public static float WheelOnRumbleStripFr(this byte[] bytes) { return GetSingle(bytes, 120); }
        public static float WheelOnRumbleStripRl(this byte[] bytes) { return GetSingle(bytes, 124); }
        public static float WheelOnRumbleStripRr(this byte[] bytes) { return GetSingle(bytes, 128); }
        public static float WheelInPuddleFl(this byte[] bytes) { return GetSingle(bytes, 132); }
        public static float WheelInPuddleFr(this byte[] bytes) { return GetSingle(bytes, 136); }
        public static float WheelInPuddleRl(this byte[] bytes) { return GetSingle(bytes, 140); }
        public static float WheelInPuddleRr(this byte[] bytes) { return GetSingle(bytes, 144); }
        public static float SurfaceRumbleFl(this byte[] bytes) { return GetSingle(bytes, 148); }
        public static float SurfaceRumbleFr(this byte[] bytes) { return GetSingle(bytes, 152); }
        public static float SurfaceRumbleRl(this byte[] bytes) { return GetSingle(bytes, 156); }
        public static float SurfaceRumbleRr(this byte[] bytes) { return GetSingle(bytes, 160); }
        public static float TireSlipAngleFl(this byte[] bytes) { return GetSingle(bytes, 164); }
        public static float TireSlipAngleFr(this byte[] bytes) { return GetSingle(bytes, 168); }
        public static float TireSlipAngleRl(this byte[] bytes) { return GetSingle(bytes, 172); }
        public static float TireSlipAngleRr(this byte[] bytes) { return GetSingle(bytes, 176); }
        public static float TireCombinedSlipFl(this byte[] bytes) { return GetSingle(bytes, 180); }
        public static float TireCombinedSlipFr(this byte[] bytes) { return GetSingle(bytes, 184); }
        public static float TireCombinedSlipRl(this byte[] bytes) { return GetSingle(bytes, 188); }
        public static float TireCombinedSlipRr(this byte[] bytes) { return GetSingle(bytes, 192); }
        public static float SuspensionTravelMetersFl(this byte[] bytes) { return GetSingle(bytes, 196); }
        public static float SuspensionTravelMetersFr(this byte[] bytes) { return GetSingle(bytes, 200); }
        public static float SuspensionTravelMetersRl(this byte[] bytes) { return GetSingle(bytes, 204); }
        public static float SuspensionTravelMetersRr(this byte[] bytes) { return GetSingle(bytes, 208); }
        public static uint CarOrdinal(this byte[] bytes) { return GetUInt8(bytes, 212); }
        public static uint CarClass(this byte[] bytes) { return GetUInt8(bytes, 216); }
        public static uint CarPerformanceIndex(this byte[] bytes) { return GetUInt8(bytes, 220); }
        public static uint DriveTrain(this byte[] bytes) { return GetUInt8(bytes, 224); }
        public static uint NumCylinders(this byte[] bytes) { return GetUInt8(bytes, 228); }
    }
}