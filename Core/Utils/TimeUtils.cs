﻿using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BricksBucket
{
    /// <summary>
    ///
    /// Time Utils.
    ///
    /// <para>
    /// Useful tools to manage time.
    /// </para>
    ///
    /// <para> By Javier García | @jvrgms | 2019 </para>
    ///
    /// </summary>
    public static class TimeUtils
    {

        #region Time Test System

        /// <summary> History of tests. </summary>
        private static readonly Dictionary<string, TimeTestData>
        _tests = new Dictionary<string, TimeTestData> ();

        /// <summary> Name of the last test. </summary>
        private static string _lastStaticTest = string.Empty;

        /// <summary>
        /// Starts or resume a test of time.
        /// </summary>
        /// <param name="title">Title of the test.</param>
        /// <param name="useMilliseconds">Whether use milliseconds.</param>
        public static void
        StartTest (string title, bool useMilliseconds = false)
        {
            if (string.IsNullOrWhiteSpace (title))
                throw new Exception (
                    "An empty or null title is invalid for a time test."
                );

            if (_tests.ContainsKey (title))
                _tests[title].Timer.Start ();
            else
            {
                _lastStaticTest = title;
                _tests[_lastStaticTest] = new TimeTestData (title, useMilliseconds);
            }
        }

        /// <summary>
        /// Pauses the specified time time.
        /// </summary>
        /// <param name="title">Name of the test to pause.</param>
        public static void
        PauseTest (string title = null)
        {
            title = string.IsNullOrWhiteSpace (title) ? _lastStaticTest : title;

            if (!_tests.ContainsKey (title))
            {
                DebugUtils.LogWarning.Debugging (
                    "The test ", title, " has not being initialized."
                );
                return;
            }

            _tests[title].Timer.Stop ();
        }

        /// <summary>
        /// Ends the specified time test.
        /// </summary>
        /// <param name="title">Name of the test.</param>
        public static void EndTest (string title = null)
        {
            title = string.IsNullOrWhiteSpace (title) ? _lastStaticTest : title;

            if (!_tests.ContainsKey (title))
            {
                DebugUtils.LogWarning.Debugging (
                    "The test ", title, " has not being initialized."
                );
                return;
            }

            _tests[title].End ();
            _tests.Remove (title);
            _lastStaticTest = string.Empty;
        }

        #region Nested Classes

        /// <summary>
        ///
        /// Time Test Data.
        ///
        /// <para>
        /// Structure to stores data of a test.
        /// </para>
        ///
        /// <para> By Javier García | @jvrgms | 2019 </para>
        ///
        /// </summary>
        private struct TimeTestData
        {
            #region TestData Class Members

            /// <summary> Timer to accuarately measure elapsed time. </summary>
            public readonly Stopwatch Timer;

            /// <summary> Title of test. </summary>
            private readonly string _testTitle;

            /// <summary> Wether use milliseconds or seconds. </summary>
            private readonly bool _precise;

            /// <summary> Layer where to make logs. </summary>
            private readonly LogLayer _logLayer;

            #endregion

            #region TestData Constructor

            /// <summary>
            /// Creates and Initialize a new test.
            /// </summary>
            /// <param name="testTitle">Name of the test.</param>
            /// <param name="precise">Wether to use second or milis.</param>
            /// <param name="logLayer">Layer where to logs test data.</param>
            public TimeTestData (
                string testTitle,
                bool precise = false,
                LogLayer logLayer = LogLayer.Debug
            )
            {
                _testTitle = testTitle;
                _precise = precise;
                _logLayer = logLayer;
                Timer = Stopwatch.StartNew ();
            }

            #endregion

            #region TestData Class Implementation

            /// <summary>
            /// Ends the test just on debug mode.
            /// </summary>
            [Conditional ("DEBUG")]
            public void End ()
            {
                var ms = Timer.ElapsedMilliseconds;
                var elapsedValue = _precise ? ms : ms / 1000f;
                var symbol = _precise ? "ms" : "s";

                DebugUtils.LogWarning.OnLayer (
                    _logLayer,
                    new object[] {
                        "Time Test ", _testTitle, ":", elapsedValue, symbol
                    }
                );
            }

            #endregion
        }

        /// <summary>
        ///
        /// Time Test.
        ///
        /// <para>
        /// History for time tests.
        /// </para>
        ///
        /// <para> By Javier García | @jvrgms | 2019 </para>
        ///
        /// </summary>
        public class TimeTest : IDisposable
        {
            #region Test Members

            /// <summary> Title of the test to dispose. </summary>
            private readonly string _disposableTest;

            #endregion

            #region Test Constructor

            /// <summary>
            /// Creates a new test of time.
            /// </summary>
            /// <param name="title">Name of the test.</param>
            /// <param name="useMilliseconds">Wether use millis.</param>
            public TimeTest (string title, bool useMilliseconds = false)
            {
                _disposableTest = title;
                _tests[_disposableTest] = new TimeTestData (
                    testTitle: title,
                    precise: useMilliseconds
                );
            }

            #endregion

            #region IDisposable Implementation

            /// <summary>
            /// Disposes thecurrent instance.
            /// </summary>
            public void Dispose ()
            {
                _tests[_disposableTest].End ();
                _tests.Remove (_disposableTest);
            }

            #endregion
        }

        #endregion

        #endregion



        #region Coroutines

        /// <summary>
        /// Invoke Action on Delay.
        /// </summary>
        /// <param name="waitSeconds"> Seconds to wait. </param>
        /// <param name="action"> Action to execute. </param>
        /// <param name="scaledTime"> Wether to use unscaled time. </param>
        /// <returns> IEnumerator. </returns>
        public static IEnumerator
        DelayedAction (float waitSeconds, Action action, bool scaledTime = true)
        {
            if (scaledTime)
                yield return new WaitForSeconds (waitSeconds);
            else
                yield return new WaitForUnscaledSeconds (waitSeconds);

            if (action != null)
                action.Invoke ();
        }

        /// <summary>
        /// Invokes the action after one frame.
        /// </summary>
        /// <param name="action">Action to execute.</param>
        /// <returns>IEnumerator.</returns>
        public static IEnumerator DelayedAction (Action action)
        {
            yield return null;

            if (action != null)
                action.Invoke ();
        }

        /// <summary>
        /// Invokes during the specified duration the OnUpdate callback.
        /// </summary>
        /// <param name="duration">Duration of the coroutine.</param>
        /// <param name="onUpdate">Callback called each time.</param>
        /// <param name="onComplete">Called when coroutine finishes.</param>
        /// <param name="scaledTime">Wether use scaled time.</param>
        /// <returns></returns>
        public static IEnumerator
        UpdateForSeconds (
            float duration,
            Action<float> onUpdate,
            Action onComplete = null,
            bool scaledTime = true
        ) {

            if (duration > 0)
            {
                if (scaledTime)
                {
                    float time = 0;
                    while (time < duration)
                    {
                        float t = 1 - ((duration - time) / duration);
                        onUpdate?.Invoke (t);

                        yield return null;
                        time += Time.deltaTime;
                    }
                }
                else
                {
                    float time = Time.realtimeSinceStartup + duration;
                    float t = 0;
                    while (t < 1)
                    {
                        t = 1 - (time - Time.realtimeSinceStartup) / duration;
                        onUpdate?.Invoke (t);
                        yield return null;
                    }
                }

                onUpdate?.Invoke (1);
                onComplete?.Invoke ();
            }
        }

        #endregion

    }

    /// <summary>
    ///
    /// Wait for Unscaled Seconds.
    ///
    /// <para>
    /// Suspends the coroutine execution for the given amount of seconds
    /// without using scaled time.
    /// </para>
    ///
    /// <para> By Javier García | @jvrgms | 2019 </para>
    ///
    /// </summary>
    public class WaitForUnscaledSeconds : CustomYieldInstruction
    {
        #region Class Members

        /// <summary> Time to wait. </summary>
        private readonly float _waitTime;

        #endregion

        #region Accessors

        /// <summary> Wether keep waiting or stops. </summary>
        public override bool keepWaiting
        {
            get { return Time.realtimeSinceStartup < _waitTime; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Suspends the coroutine execution for the given amount of
        /// seconds without using scaled time.
        /// </summary>
        /// <param name="waitTime"> Time in seconds to wait. </param>
        public WaitForUnscaledSeconds (float waitTime)
        {
            _waitTime = Time.realtimeSinceStartup + waitTime;
        }

        #endregion
    }



}