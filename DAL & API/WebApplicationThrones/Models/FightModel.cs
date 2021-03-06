﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace WebApplicationThrones.Models
{
    public class FightModel
    {
        public int ID { get; set; }

        [Display(Name = "Attacking Army ID", AutoGenerateField = false)]
        public int AttArmy { get; set; }

        [Display(Name = "House Name")]
        public ArmyModel AttArmy_obj { get; set; }

        [Display(Name = "Defending Army ID", AutoGenerateField = false)]
        public int DefArmy { get; set; }

        [Display(Name = "Opponents")]
        public ArmyModel DefArmy_obj { get; set; }

        [Display(Name = "Victorious Army ID", AutoGenerateField = false)]
        public int WinningArmy { get; set; }

        [Display(Name = "Winner")]
        public ArmyModel WinningArmy_obj { get; set; }

        public FightModel()
        {

        }

    }
}
