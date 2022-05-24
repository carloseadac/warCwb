﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;

namespace warCWBv2
{
    public partial class MapForm : Form
    {
        static List<Territorio> territorioList = new List<Territorio>();
        Graphics g;
        List<Zona> zonas = GetZonas();
        static Team[] teams = CreateTeams();
        public MapForm()
        {
            InitializeComponent();
        }

        private void MapForm_Load(object sender, EventArgs e)
        {
            pb.Image = new Bitmap(pb.Width, pb.Height);
            g = Graphics.FromImage(pb.Image);
            g.Clear(Color.White);
            pb.Refresh();

            MapManager mm = new MapManager();
            CreateTerritorio();
            Timer tm = new Timer();
            tm.Interval = 50;

            tm.Tick += delegate
            {
                pb.Image = mm.Map;
            };
            tm.Start();

            mm.Initialize();
            mm.ClearRandom(territorioList);
            mm.Close();

            pb.MouseDown += (o, mea) =>
            {
                Console.WriteLine(mea.Location.ToString());
                mm.Initialize();
                mm.Clear(Color.Green, mea.Location);
                mm.Close();
            };

            foreach(var t in FindTerritorio("água verde").GetAdjacente()) 
            {
                var q = GetAllTeams().Where(x => x.GetTerritorios().Contains(t)).Single();
                Console.WriteLine($"{t.GetName()} - {q.GetColor()}");
                mm.Initialize();
                mm.Clear(Color.Purple, t.GetCoord());
                mm.Close();
            }
        }


        public static List<Zona> GetZonas()
        {
            List<Zona> list = new List<Zona>();
            Zona cic = new Zona(3);
            Zona portao = new Zona(6);
            Zona bairronovo = new Zona(3);
            Zona pinheirinho = new Zona(3);
            Zona stafelicidade = new Zona(4);
            Zona boqueirao = new Zona(3);
            Zona cajuru = new Zona(3);
            Zona matriz = new Zona(10);
            Zona boavista = new Zona(4);

            list.AddRange(new[] { cic, portao, bairronovo, pinheirinho, stafelicidade, boqueirao, cajuru, matriz, boavista });

            return list;
        }
        public static Team[] CreateTeams()
        {
            Team team1 = new Team(Color.Red);
            Team team2 = new Team(Color.Yellow);
            Team team3 = new Team(Color.Green);
            Team team4 = new Team(Color.Blue);

            return new Team[] { team1, team2, team3, team4 };
        }

        // reescrever essa parte inteira
        public void CreateTerritorio()
        {
            List<Territorio> list = new List<Territorio>();
            
            // trigger warning: murilo moment
            // YANDERE DEV MOMENT assassinado Moll
            list.Add(new Territorio(false, new Point(233, 263), zonas[1], "água verde"));
            zonas[1].InsertTerr(list[0]);
            list.Add(new Territorio(false, new Point(336, 375), zonas[5], "alto boqueirão"));
            zonas[5].InsertTerr(list[1]);
            list.Add(new Territorio(false, new Point(320, 182), zonas[7], "alto da xv"));
            zonas[7].InsertTerr(list[2]);
            list.Add(new Territorio(false, new Point(217, 220), zonas[7], "batel"));
            zonas[7].InsertTerr(list[3]);
            list.Add(new Territorio(false, new Point(293, 105), zonas[8], "boa vista"));
            zonas[8].InsertTerr(list[4]);
            list.Add(new Territorio(false, new Point(342, 453), zonas[5], "boqueirão"));
            zonas[5].InsertTerr(list[5]);
            list.Add(new Territorio(false, new Point(87, 116), zonas[4], "buitavinha"));
            zonas[4].InsertTerr(list[6]);
            list.Add(new Territorio(false, new Point(308, 149), zonas[7], "cabral"));
            zonas[7].InsertTerr(list[7]);
            list.Add(new Territorio(false, new Point(283, 24), zonas[8], "cachoeira"));
            zonas[8].InsertTerr(list[8]);
            list.Add(new Territorio(false, new Point(395, 260), zonas[6], "cajuru"));
            zonas[6].InsertTerr(list[9]);
            list.Add(new Territorio(false, new Point(149, 247), zonas[4], "campo comprido"));
            zonas[4].InsertTerr(list[10]);
            list.Add(new Territorio(false, new Point(142, 617), zonas[3], "campo de santana"));
            zonas[3].InsertTerr(list[11]);
            list.Add(new Territorio(false, new Point(265, 209), zonas[7], "centro"));
            zonas[7].InsertTerr(list[12]);
            list.Add(new Territorio(false, new Point(258, 155), zonas[7], "centro cívico"));
            zonas[7].InsertTerr(list[13]);
            list.Add(new Territorio(false, new Point(132, 383), zonas[0], "cic"));
            zonas[0].InsertTerr(list[14]);
            list.Add(new Territorio(false, new Point(151, 318), zonas[1], "fazendinha"));
            zonas[1].InsertTerr(list[15]);
            list.Add(new Territorio(false, new Point(299, 541), zonas[2], "ganchinho"));
            zonas[2].InsertTerr(list[16]);
            list.Add(new Territorio(false, new Point(316, 222), zonas[7], "jardim botânico"));
            zonas[7].InsertTerr(list[17]);
            list.Add(new Territorio(false, new Point(334, 271), zonas[5], "jardim das américas"));
            zonas[5].InsertTerr(list[18]);
            list.Add(new Territorio(false, new Point(227, 186), zonas[7], "mercês"));
            zonas[7].InsertTerr(list[19]);
            list.Add(new Territorio(false, new Point(211, 341), zonas[1], "novo mundo"));
            zonas[1].InsertTerr(list[20]);
            list.Add(new Territorio(false, new Point(74, 191), zonas[4], "orleans"));
            zonas[4].InsertTerr(list[21]);
            list.Add(new Territorio(false, new Point(268, 299), zonas[1], "parolin"));
            zonas[1].InsertTerr(list[22]);
            list.Add(new Territorio(false, new Point(46, 307), zonas[0], "passaúna"));
            zonas[0].InsertTerr(list[23]);
            list.Add(new Territorio(false, new Point(218, 97), zonas[8], "pilarzinho"));
            zonas[8].InsertTerr(list[24]);
            list.Add(new Territorio(false, new Point(217, 415), zonas[3], "pinheirinho"));
            zonas[3].InsertTerr(list[25]);
            list.Add(new Territorio(false, new Point(198, 302), zonas[1], "portão"));
            zonas[1].InsertTerr(list[26]);
            list.Add(new Territorio(false, new Point(297, 248), zonas[7], "rebouças"));
            zonas[7].InsertTerr(list[27]);
            list.Add(new Territorio(false, new Point(363, 68), zonas[8], "santa cândida"));
            zonas[8].InsertTerr(list[28]);
            list.Add(new Territorio(false, new Point(143, 157), zonas[4], "santa felicidade"));
            zonas[4].InsertTerr(list[29]);
            list.Add(new Territorio(false, new Point(70, 385), zonas[0], "são miguel"));
            zonas[0].InsertTerr(list[30]);
            list.Add(new Territorio(false, new Point(280, 471), zonas[2], "sitio cercado"));
            zonas[2].InsertTerr(list[31]);
            list.Add(new Territorio(false, new Point(379, 158), zonas[8], "tarumã"));
            zonas[8].InsertTerr(list[32]);
            list.Add(new Territorio(false, new Point(151, 520), zonas[3], "tatuquara"));
            zonas[3].InsertTerr(list[33]);
            list.Add(new Territorio(false, new Point(383, 335), zonas[6], "uberaba"));
            zonas[6].InsertTerr(list[34]);
            list.Add(new Territorio(false, new Point(232, 564), zonas[2], "umbará"));
            zonas[2].InsertTerr(list[35]);
            list.Add(new Territorio(false, new Point(208, 151), zonas[4], "vista alegre"));
            zonas[4].InsertTerr(list[36]);
            list.Add(new Territorio(false, new Point(272, 386), zonas[5], "xaxim"));
            zonas[5].InsertTerr(list[37]);

            territorioList = list;
            InsertAdjacent();
        }
        public Territorio FindTerritorio(string name)
        {
            return territorioList.Where(t => t.GetName() == name).Single();
        }
        public void InsertAdjacent()
        {
            FindTerritorio("água verde").InsertTerr(new Territorio[]{ FindTerritorio("batel"), FindTerritorio("portão"),
                 FindTerritorio("parolin"), FindTerritorio("fazendinha"), FindTerritorio("campo comprido"),
                 FindTerritorio("centro"), FindTerritorio("rebouças")});
            // fazer para cada um dos territorios!!!!!!!!!!!
        }

        public static Team[] GetAllTeams()
        {
            return teams;
        }
    }

}
