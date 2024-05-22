using Easter.Models.Bunnies.Contracts;
using Easter.Models.Dyes;
using Easter.Models.Dyes.Contracts;
using Easter.Models.Eggs.Contracts;
using Easter.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Easter.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }

        public void Color(IEgg egg, IBunny bunny)
        {
            if (bunny.Energy > 0)
            {
                while (true)
                {
                    Dye dye = null;
                    foreach (Dye currDye in bunny.Dyes)
                    {
                        if (!currDye.IsFinished())
                        {
                            dye = currDye;
                            break;
                        }
                    }
                    if (dye != null)
                    {
                        while (!dye.IsFinished() &&
                            bunny.Energy > 0 &&
                            !egg.IsDone())
                        {
                            bunny.Work();
                            egg.GetColored();
                            dye.Use();
                        }
                        if (bunny.Energy == 0 || egg.IsDone())
                        {
                            break;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
                
            }
        }
    }
}
