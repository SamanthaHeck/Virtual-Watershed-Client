﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
//using System.Threading.Tasks;

namespace NetworkTest
{
    class Program
    {
        static String MimeUrlOne = "url://http://129.24.63.65//apps/my_app/datasets/2d78540a-fdea-4dc3-bf68-c9508bb1166f/services/ogc/wcs?request=GetCoverage&service=WCS&version=1.1.2&Identifier=DCEsqrExtent_epsg_4326_new&InterpolationType=NEAREST_NEIGHBOUR&format=image/bil&store=false&GridBaseCRS=urn:ogc:def:crs:epsg::4326&CRS=EPSG:4326&bbox=-116.22783700393,43.6501960099275,-116.015090235342,43.770631547369&width=1025&height=1025";
        static String MimeUrlTwo = "url://http://129.24.63.65//apps/my_app/datasets/794324ba-22c4-4847-8e0d-277a8d64cf75/services/ogc/wcs?request=GetCoverage&service=WCS&version=1.1.2&Identifier=n39w115&InterpolationType=NEAREST_NEIGHBOUR&format=image/bil&store=false&GridBaseCRS=urn:ogc:def:crs:epsg::4326&CRS=EPSG:4326&bbox=-115.001666666667,37.9983333333333,-113.998333333333,39.0016666666674&width=1025&height=1025";
        static String TestFileOne = "file://C:/Users/hpcvi_000/Desktop/NetworkingTest/NetworkingTest/NetworkingTest/NetworkTest/NetworkTest/bin/Debug/test.hdr";
        static String TestPNG = "url://http://129.24.63.65//apps/my_app//datasets/2d78540a-fdea-4dc3-bf68-c9508bb1166f/services/ogc/wms?SERVICE=wms&Request=GetMap&width=512&height=512&layers=DCEsqrExtent_epsg_4326_new&bbox=-116.227837004,43.6501960099,-116.015090235,43.7706315474&format=image/png&Version=1.1.1&srs=epsg:4326";
        static String WCSCapabilitiesS = "url://http://129.24.63.65//apps/my_app/datasets/48cdb02d-7df8-4149-a6cb-16706e696b8c/services/ogc/wcs?SERVICE=wcs&REQUEST=GetCapabilities&VERSION=1.1.2";
        static String WMSCapabilitiesS = "url://http://129.24.63.65//apps/my_app/datasets/712c4319-fb36-4e87-b670-90aac2f5e133/services/ogc/wms?SERVICE=wms&REQUEST=GetCapabilities&VERSION=1.1.1";
        static String WFSCapabilitiesS = "url://http://129.24.63.65//apps/my_app/datasets/712c4319-fb36-4e87-b670-90aac2f5e133/services/ogc/wfs?SERVICE=wfs&REQUEST=GetCapabilities&VERSION=1.0.0";
        static String WCSDescribeCoverageS = "url://http://129.24.63.65//apps/my_app/datasets/b51ce262-ee85-4910-ad2b-dcce0e5b2de7/services/ogc/wcs?request=DescribeCoverage&service=WCS&version=1.1.2&identifiers=output_srtm&";
        static String VWPString = "http://vwp-dev.unm.edu/";
        static VWClient vwc;
        static DataObserver obs;
        static void Main( string[] args )
        {
<<<<<<< HEAD
            
            DataFactory df = new DataFactory();
            VWClient vwClient = new VWClient();
            DataRecord a, b, c;
            VWClient vw = new VWClient();
            a = new DataRecord( "Create_Url" );
            b = new DataRecord( "Create_File" );
            c = new DataRecord( "Export_Url" );
            //FileBasedCache.Insert<int>("SOMEINT", 1);
            try
            {
                //Console.WriteLine(FileBasedCache.Get<int>("SOMEINT"));
            }
            catch (Exception e)
=======
            NetworkManager nm = new NetworkManager();
            obs = new DataObserver();
            vwc = new VWClient(new DataFactory(nm),nm);
            nm.Subscribe(vwc);
            nm.Subscribe(obs);

            vwc.RequestRecords(PrintDataRecords,0, 15);
            
            Console.ReadKey();
            Console.WriteLine("FINISHED EVERYTHING");
        }

        static void PrintDataRecords(List<DataRecord> Records)
        {
            List<DataRecord> Rs = new List<DataRecord>();
            foreach (var i in Records)
>>>>>>> origin
            {
                Console.WriteLine("NAME: " + i.name);
                Rs.Add(i);
                vwc.GetMetaData(PrintMetaData, Rs);
            }

            // ================================================
            // TEST FOR DOWNLOAD VS CACHED DATA_RECORD EQUALITY
            // ================================================
            List<DataRecord> cachedRecords = FileBasedCache.Get<List<DataRecord>>("RECORD");

            for (int i = 0; i < Rs.Count; i++)
            {
                if (Rs[i].name == cachedRecords[i].name)
                {
                    Console.WriteLine("Record " + i + " is equal!");
                }
                else
                {
                    Console.WriteLine("Record " + i + " is NOT equal!");
                }
            }
            FileBasedCache.Clear();
            Console.WriteLine("CACHE CLEARED");
            FileBasedCache.Insert<List<DataRecord>>("RECORD", Rs);
            Console.WriteLine("RECORDS LOADED TO CACHE");

            // ================================================
            // END OF TEST
            // ================================================

        }

<<<<<<< HEAD
            //Console.WriteLine(FileBasedCache.Get<List<DataRecord>>("RECORDS2")[0].Lines.Count);
            Console.ReadKey();
            //FileBasedCache.Insert<TestSerialialization>("TEST", new TestSerialialization());
            
            //List<DataRecord> drs = new List<DataRecord>();
            //drs.Add(a);
            //df.Import( "WCS_BIL", a, MimeUrlOne );
            //df.Export( "WCS_BIL", MimeUrlTwo, "./", "Test" );
           // df.Export("WMS_PNG", TestPNG, "./","Test2");
           // df.Export("WCS_CAP", WCSCapabilitiesS, "./", "Test3");
            //df.Export("WFS_CAP", WFSCapabilitiesS, "./", "Test4");
          // // df.Export("WMS_CAP", WMSCapabilitiesS, "./", "Test5");
          //  df.Export("WCS_DC", WCSDescribeCoverageS, "./", "Test6");
          //  df.Export("WFS_GML",WFSFeatureString, "./","Test7");
            //df.Import("WMS_PNG", drs,TestPNG);
            ////df.Import("WCS_CAP", a, WCSCapabilitiesS);
            ////df.Import("WFS_CAP", a, WFSCapabilitiesS);
            ////df.Import("WMS_CAP", a, WMSCapabilitiesS);
            ////df.Import("WCS_DC", a, WCSDescribeCoverageS);
            List<DataRecord> records = new List<DataRecord>();
            
            //df.Import("VW_JSON", records, "url://http://129.24.63.65//apps/my_app/search/datasets.json?offset=0&limit=15");
            //df.TestStringDownload("http://www.google.com");
            //df.Import( "WCS_BIL", b, TestFileOne );
            //Console.WriteLine("DONE DOWNLOADING");
            /*for (int i = 0; i < 1000000; i++ )
            {
                vw.Download(i.ToString(), new DataRecord(), "wcs");
            }*/
            //var url2 = vwClient.RequestRecords(0, 15);
            var url = vwClient.RequestRecords(0, 15);
            List<DataRecord> records2;
               while (DataTracker.CheckStatus(url) != DataTracker.Status.FINISHED) { } //Console.WriteLine("Waiting"); }
               records2 = DataTracker.JobFinished(url);
               List<DataRecord> cachedRecords = FileBasedCache.Get<List<DataRecord>>("RECORD");
               for (int i = 0; i < records2.Count; i++)
               {
                   if (records2[i] == cachedRecords[i])
                   {
                       Console.WriteLine("record " + i + " is equal");
                   }
                   else
                   {
                       Console.WriteLine("record " + i + " is NOT equal");
                   }
               }
                   
               FileBasedCache.Insert<List<DataRecord>>("RECORD", records2);
               vwClient.Download("testJob", records2[0], "wfs");
                //Console.WriteLine(records2.Count());
                //while (DataTracker.CheckStatus(url2) != DataTracker.Status.FINISHED) { } //Console.WriteLine("Waiting"); }
                //records2 = DataTracker.JobFinished(url2);
                //Console.WriteLine(records2.Count());
                //Console.WriteLine("Seeing Keys");
                /*foreach(var i in records2)
                {
                    Console.WriteLine(i.name);
                    foreach(var k in i.services.Keys)
                    {
                        Console.WriteLine(k);
                    }
                }*/
                //Console.ReadKey();
                //vwClient.Download("testJob", records2[0], "wfs");

                while (DataTracker.CheckStatus("testJob") != DataTracker.Status.FINISHED)
                {
                    //Console.WriteLine("HELLO");
                }
                //FileBasedCache.Insert<List<DataRecord>>("RECORDS2", records2);
                //Console.WriteLine(records2[0].Lines.Count);
                Console.WriteLine("COMPLETED! DONE!");
                Console.ReadKey();
            // Note: Function to say if downloads are done or not, + a logger for the past n downloads
                //FileBasedCache.Clear();
=======
        static void PrintMetaData(List<DataRecord> Records)
        {
            Console.WriteLine("METADATA");
            foreach (var i in Records)
            {
                Console.WriteLine(i.metaData);
            }
>>>>>>> origin
        }

        static void download()
        {  
            Console.WriteLine("Hello from another thread");
        }
    }
}
