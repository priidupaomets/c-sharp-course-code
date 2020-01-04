using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InheritanceAndComposition
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Logimise kasutamise näide

            ILogger logger = new ConsoleLogger();

            logger.Log("Alustame");

            Thread.Sleep(1000);

            logger.Log("Lõpetame");

            Console.WriteLine("Tehtud");

            #endregion

            #region Elusolendite näite tegemine minimaalse põlvnemise ja liideste abil

            var elukad = new List<Elusolend>();

            elukad.Add(new Inimene());
            elukad.Add(new Part());

            foreach (var olend in elukad)
            {
                if (olend is IUjuv)
                {
                    (olend as IUjuv).Uju();
                }
            }

            #endregion

            #region Graafikaobjektide loomine ja kasutamine

            var objektid = new List<GraphicsObject>();

            objektid.Add(new Text()
            {
                Location = new Point(10, 10),
                Size = new Size(5, 5),
                Title = "Pealkiri"
            });
            objektid.Add(new Picture()
            {
                Location = new Point(20, 5),
                Size = new Size(5, 5),
                Url = "http://..."
            });
            objektid.Add(new Rectangle()
            {
                Location = new Point(5, 15),
                Size = new Size(5, 5)
            });


            foreach (var obj in objektid)
            {
                obj.Draw();
            }

            #endregion

            Console.ReadLine();
        }
    }

 

}
