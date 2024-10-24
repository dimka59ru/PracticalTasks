using PracticalTasks.Task1App.Models;

namespace PracticalTasks.Task1App.Cameras
{
  /// <summary>
  /// Простая фотокамера.
  /// </summary>
  internal class SimplePhotoCamera
  {
    #region События

    /// <summary>
    /// Событие готовности фото.
    /// </summary>
    public event EventHandler<TakePhotoEventArgs>? TakePhoto;

    /// <summary>
    /// Деллает фото.
    /// </summary>
    public void OnTakePhoto()
    {
      var args = new TakePhotoEventArgs(new Photo());
      this.TakePhoto?.Invoke(this, args);
    }

    #endregion
  }
}
