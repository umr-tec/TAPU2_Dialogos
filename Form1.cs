using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Windows.Forms;
//Agregar las librearias de Video
using AForge.Video;
using AForge.Video.DirectShow;

namespace TAPU2_Dialogos
{
    public partial class Form1 : Form
    {
        //Variables globales
        FilterInfoCollection infoCollection;
        VideoCaptureDevice captureDevice;
        Captura capturaFoto;

        public Form1()
        {
            InitializeComponent();
            capturaFoto = new Captura();
            capturaFoto.pbCaptura.BackgroundImageLayout = ImageLayout.Zoom;
            capturaFoto.Show();
        }

        private void videoSourcePlayer1_Click(object sender, EventArgs e)
        {

        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            //Se crea un objeto para imprimir            
            //Para obtener obtener la clase PrintDocument se debe agregar la libreria
            //using System.Drawing.Printing;
            PrintDocument documentoImprimir = new PrintDocument();
            //Se establece un evemto de tipo PrintPageEventHandler al objeto creado en la linea anterior
            //Este evento buscará un método llamado documentPrintaPage el cual se determinará que se imprimira
            //y que se programa mas adelante
            documentoImprimir.PrintPage += new PrintPageEventHandler(documentPrintaPage);
            //se crea un objeto PrintPreviewDialog, el cual es el visualizador que se cargará para imprimir
            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = documentoImprimir;
            printPreviewDialog.ShowDialog(this);

        }

        /// <summary>
        /// Método que tendrá los elementos que se desean imprimir, cabe mencionar que al ser un
        /// método controlado por unn evento debe recibir un parametro de tipo object y un patametro asociado 
        /// al tipo de evento, en este caso un parametro de tipo PrintPageEventArgs
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void documentPrintaPage(object sender, PrintPageEventArgs e)
        {
            //se hace una llamada local a una libreria Graphics, la cual permite crear graficos en un Form
            using (Graphics graphics = CreateGraphics())            
            {
                using (Font f = new Font("Arial", 30, FontStyle.Italic))
                {
                    e.Graphics.DrawString("Ejemplo de imprimir 4°C", f, Brushes.Black, ClientRectangle.Width / 2, 100);
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Cargar videocamaras activas 
            infoCollection = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            //Recorrer el objeto infoCollection para mostrar los resultados en el comboBox1
            foreach (FilterInfo filterInfo in infoCollection)
            {
                comboBox1.Items.Add(filterInfo.Name);
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            //ACtivar la camara seleccionada y enviar señal de video
            captureDevice = new VideoCaptureDevice(infoCollection[comboBox1.SelectedIndex].MonikerString);
            videoSourcePlayer1.VideoSource = captureDevice;
            videoSourcePlayer1.Start();
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            //Detener la señal de video
            videoSourcePlayer1.SignalToStop();
        }

        private void btnFoto_Click(object sender, EventArgs e)
        {
            //Tomar una foto del videoSourcePlayer1 y enviarla al Picture del form llamado Captura
            //Se crea un objeto de tipo SaveFileDialog, este control también se úede agregar directamente del diseñador
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            //Se filtan los formatos que pueden ser guardardados, en este caso solo podrán guardarse archivos en formato jpg
            saveFileDialog.Filter = "Imagen JPG |*.jpg";
            //mostrar el fileDialog
            saveFileDialog.ShowDialog();
            //Guarfdar la imagen, antes de guardar con un if se valida que el archivo a gurdar tenga texto en el nombre
            if (saveFileDialog.FileName != null)
            {
                //Se crea un mapa de bits (imagen) con la clase Bitmap
                //En este objeto Bitmap se carga un frame del videoSourcePlayer1
                Bitmap imagenPorGuardar = videoSourcePlayer1.GetCurrentVideoFrame();
                //Se guarda la imagen haciendo uso del saveFileDialog, y estableciendo un formato de guardado
                //para ver la clase ImageFormat se debe agregar la libreria using System.Drawing.Imaging;
                imagenPorGuardar.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                imagenPorGuardar.Dispose();
            }
        }
    }
}
