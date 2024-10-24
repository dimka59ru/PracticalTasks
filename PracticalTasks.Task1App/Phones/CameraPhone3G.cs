using PracticalTasks.Task1App.Cameras;

namespace PracticalTasks.Task1App.Phones
{
  /// <summary>
  /// 3G телефон с камерой.
  /// </summary>
  internal class CameraPhone3G : Phone3G, IDisposable
  {
    #region Поля и свойства

    /// <summary>
    /// Фотокамера.
    /// </summary>
    private readonly SimplePhotoCamera photoCamera;

    #endregion

    #region Методы

    private void PhotoCameraTakePhotoHandler(object? sender, Models.TakePhotoEventArgs e)
    {
      Console.WriteLine($"Получено фото {e.Photo.Data}");
    }

    /// <summary>
    /// Сделать фото.
    /// </summary>
    public void TakePhoto()
    {
      this.photoCamera.OnTakePhoto();
    }

    #endregion

    #region IDisposable

    public void Dispose()
    {
      photoCamera.TakePhoto -= this.PhotoCameraTakePhotoHandler;
    }

    #endregion

    #region Конструкторы

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="imei">imei телефона.</param>
    /// <param name="simNumber">Номер симкарты.</param>
    public CameraPhone3G(string imei, int simNumber) : base(imei, simNumber)
    {
      this.photoCamera = new SimplePhotoCamera();
      photoCamera.TakePhoto += this.PhotoCameraTakePhotoHandler;
    }

    #endregion
  }
}
