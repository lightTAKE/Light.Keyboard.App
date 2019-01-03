using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Light.Keyboard.App.Logitech
{
    public class LogitechGSDK
    {
        private const string LoitechLedEnginesWrapper = "LogitechLedEnginesWrapper";

        private const int LOGI_DEVICETYPE_MONOCHROME_ORD = 0;
        private const int LOGI_DEVICETYPE_RGB_ORD = 1;
        private const int LOGI_DEVICETYPE_PERKEY_RGB_ORD = 2;

        public const int LOGI_DEVICETYPE_MONOCHROME = (1 << LOGI_DEVICETYPE_MONOCHROME_ORD);
        public const int LOGI_DEVICETYPE_RGB = (1 << LOGI_DEVICETYPE_RGB_ORD);
        public const int LOGI_DEVICETYPE_PERKEY_RGB = (1 << LOGI_DEVICETYPE_PERKEY_RGB_ORD);
        public const int LOGI_DEVICETYPE_ALL = (LOGI_DEVICETYPE_MONOCHROME | LOGI_DEVICETYPE_RGB | LOGI_DEVICETYPE_PERKEY_RGB);

        public const int LOGI_LED_BITMAP_WIDTH = 21;
        public const int LOGI_LED_BITMAP_HEIGHT = 6;
        public const int LOGI_LED_BITMAP_BYTES_PER_KEY = 4;

        public const int LOGI_LED_BITMAP_SIZE = LOGI_LED_BITMAP_WIDTH * LOGI_LED_BITMAP_HEIGHT * LOGI_LED_BITMAP_BYTES_PER_KEY;
        public const int LOGI_LED_DURATION_INFINITE = 0;

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedInit();

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedInitWithName(String name);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedGetConfigOptionNumber([MarshalAs(UnmanagedType.LPWStr)]String configPath, ref double defaultNumber);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedGetConfigOptionBool([MarshalAs(UnmanagedType.LPWStr)]String configPath, ref bool defaultRed);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedGetConfigOptionColor([MarshalAs(UnmanagedType.LPWStr)]String configPath, ref int defaultRed, ref int defaultGreen, ref int defaultBlue);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedGetConfigOptionKeyInput([MarshalAs(UnmanagedType.LPWStr)]String configPath, StringBuilder buffer, int bufsize);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedSetTargetDevice(int targetDevice);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedGetSdkVersion(ref int majorNum, ref int minorNum, ref int buildNum);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedSaveCurrentLighting();

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedSetLighting(int redPercentage, int greenPercentage, int bluePercentage);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedRestoreLighting();

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedFlashLighting(int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration, int milliSecondsInterval);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedPulseLighting(int redPercentage, int greenPercentage, int bluePercentage, int milliSecondsDuration, int milliSecondsInterval);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedStopEffects();

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedExcludeKeysFromBitmap(KeyNames[] keyList, int listCount);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedSetLightingFromBitmap(byte[] bitmap);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedSetLightingForKeyWithScanCode(int keyCode, int redPercentage, int greenPercentage, int bluePercentage);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedSetLightingForKeyWithHidCode(int keyCode, int redPercentage, int greenPercentage, int bluePercentage);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedSetLightingForKeyWithQuartzCode(int keyCode, int redPercentage, int greenPercentage, int bluePercentage);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedSetLightingForKeyWithKeyName(KeyNames keyCode, int redPercentage, int greenPercentage, int bluePercentage);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedSaveLightingForKey(KeyNames keyName);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedRestoreLightingForKey(KeyNames keyName);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedFlashSingleKey(KeyNames keyName, int redPercentage, int greenPercentage, int bluePercentage, int msDuration, int msInterval);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedPulseSingleKey(KeyNames keyName, int startRedPercentage, int startGreenPercentage, int startBluePercentage, int finishRedPercentage, int finishGreenPercentage, int finishBluePercentage, int msDuration, bool isInfinite);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedStopEffectsOnKey(KeyNames keyName);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool LogiLedSetLightingForTargetZone(DeviceType deviceType, int zone, int redPercentage, int greenPercentage, int bluePercentage);

        [DllImport(LoitechLedEnginesWrapper, CallingConvention = CallingConvention.Cdecl)]
        public static extern void LogiLedShutdown();
    }
}