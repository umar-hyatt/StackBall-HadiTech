using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class notificationIOS : MonoBehaviour
{
    public int repeatAfterDay=1;
   public string Title="Title";
   public string Content="Content";

  private void Start()
  {
      #if UNITY_IOS
      UnityEngine.iOS.NotificationServices.ClearLocalNotifications();
      UnityEngine.iOS.NotificationServices.RegisterForNotifications(UnityEngine.iOS.NotificationType.Alert | UnityEngine.iOS.NotificationType.Badge | UnityEngine.iOS.NotificationType.Sound);
      #endif
  }
   private void OnApplicationPause(bool pauseStatus)
  {
      #if UNITY_IOS
      UnityEngine.iOS.NotificationServices.ClearLocalNotifications();
      UnityEngine.iOS.NotificationServices.CancelAllLocalNotifications();
      if(pauseStatus)
      {

      DateTime dateToNoti=DateTime.Now.AddDays(repeatAfterDay);
      UnityEngine.iOS.LocalNotification noti = new UnityEngine.iOS.LocalNotification();
      noti.fireDate=dateToNoti;
      noti.alertTitle=Title;
      noti.alertBody=Content;

      noti.repeatInterval=UnityEngine.iOS.CalendarUnit.Day;

      UnityEngine.iOS.NotificationServices.ScheduleLocalNotification(noti);
      }
      #endif
  }
}
