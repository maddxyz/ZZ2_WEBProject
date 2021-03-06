﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using EntitiesLayer;
using EntitiesLayer.DTOs;

namespace DataAccessLayer
{
    public class DalManager
    {
        private static readonly Lazy<DalManager> lazy = new Lazy<DalManager>(() => new DalManager());
        private IDal bddInterf;

        public static DalManager Instance { get { return lazy.Value; } }
        DalManager()
        {
            // Pour changer l'implémentation il suffit de modifier cette ligne
            bddInterf = new SqlServerDal();
        }
            
        public List<HouseDTO> GetHouses()
        {
            return bddInterf.GetHouses();
        }
        public HouseDTO GetHouseById(int p_id)
        {
            return bddInterf.GetHouseById(p_id);
        }
        public void AddHouse(HouseDTO house)
        {
            bddInterf.AddHouse(house);
        }
        public void EditHouse(HouseDTO house)
        {
            bddInterf.EditHouse(house);
        }
        public void DeleteHouse(int id)
        {
            bddInterf.DeleteHouse(id);
        }

        public List<WhiteWalkerDTO> GetWhiteWalkers()
        {
            return bddInterf.GetWhiteWalkers();
        }
        public WhiteWalkerDTO GetWhiteWalkerById(int p_id)
        {
            return bddInterf.GetWhiteWalkerById(p_id);
        }
        public void AddWhiteWalker(WhiteWalkerDTO ww)
        {
            bddInterf.AddWhiteWalker(ww);
        }
        public void EditWhiteWalker(WhiteWalkerDTO ww)
        {
            bddInterf.EditWhiteWalker(ww);
        }
        public void DeleteWhiteWalker(int id)
        {
            bddInterf.DeleteWhiteWalker(id);
        }

        public List<CharacterDTO> GetCharacters()
        {
            return bddInterf.GetCharacters();
        }
        public CharacterDTO GetCharacterById(int p_id)
        {
            return bddInterf.GetCharacterById(p_id);
        }
        public void AddCharacter(CharacterDTO Character)
        {
            bddInterf.AddCharacter(Character);
        }
        public void EditCharacter(CharacterDTO Character)
        {
            bddInterf.EditCharacter(Character);
        }
        public void DeleteCharacter(int id)
        {
            bddInterf.DeleteCharacter(id);
        }

        public List<FightDTO> GetFights()
        {
            return bddInterf.GetFights();
        }
        public FightDTO GetFightById(int p_id)
        {
            return bddInterf.GetFightById(p_id);
        }
        public void AddFight(FightDTO Fight)
        {
            bddInterf.AddFight(Fight);
        }
        public void EditFight(FightDTO Fight)
        {
            bddInterf.EditFight(Fight);
        }
        public void DeleteFight(int id)
        {
            bddInterf.DeleteFight(id);
        }

        public List<TerritoryDTO> GetTerritorys()
        {
            return bddInterf.GetTerritorys();
        }
        public TerritoryDTO GetTerritoryById(int p_id)
        {
            return bddInterf.GetTerritoryById(p_id);
        }
        public void AddTerritory(TerritoryDTO Territory)
        {
            bddInterf.AddTerritory(Territory);
        }
        public void EditTerritory(TerritoryDTO Territory)
        {
            bddInterf.EditTerritory(Territory);
        }
        public void DeleteTerritory(int id)
        {
            bddInterf.DeleteTerritory(id);
        }

        public List<WarDTO> GetWars()
        {
            return bddInterf.GetWars();
        }
        public WarDTO GetWarById(int p_id)
        {
            return bddInterf.GetWarById(p_id);
        }
        public void AddWar(WarDTO War)
        {
            bddInterf.AddWar(War);
        }
        /*public void EditWar(WarDTO War)
        {
            bddInterf.EditWar(War);
        }*/
        public void DeleteWar(int id)
        {
            bddInterf.DeleteWar(id);
        }
    }
}
