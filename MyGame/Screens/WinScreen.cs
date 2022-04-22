#pragma warning disable CA1416

namespace MyGame
{
    class WinScreen
    {
        public static GameState GetInput()
        {
            Draw();

            Console.CursorVisible = true;
            Console.SetCursorPosition(72, 12);

            var key = Console.ReadKey(true).Key;

            while (key != ConsoleKey.D1 && key != ConsoleKey.D2 && key != ConsoleKey.D3)
                key = Console.ReadKey(true).Key;

            if (key == ConsoleKey.D1)
                return GameState.Continue;

            else if (key == ConsoleKey.D2)
                return GameState.Play;

            else return GameState.Quit;
        }

        public static void Draw()
        {
            Console.Clear();
            Console.SetWindowSize(125, 43);
            Console.SetBufferSize(125, 43);
            Console.SetCursorPosition(0, 0);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write(@"
             dXXk       OXXk                                                          NMW                   dXXo
              0MWx    oNMNd                                                                                 KMX 
               KMWd  OWW0     lxOOOkd       xkl    lkx           dkl    lkk     dko  lkx    okd cxOOOd     lWMk 
                XMN0XMNx    xNWKdloOWWk    kMWd    NMK           0M0   dWMMx   0MXc  XMX   lWMWKxloKWMO    kMX  
                cXMMW0     OMWk     kMWd   XMK    xMMd           xMX  oWWWMx  0MXc  dMMk   kMWO    xMMk    0Wo  
                 OMMO      NMK      kMWd  xMMx    KMX            oWWooNXdkMkcOMX    0MNc   XMK     0MNc    XO   
                 KMNc      XMX     oNMK   KMN    kWMk             XWNNNl oMNNWK    lWMO   xMMx    lWMO          
                oWM0       oNMXxld0WNk    XMWOld0WMNc             0MMNo  cWMMK     OMWo   KMN     OMWo   lKK    
                cxx          lxkOkxo       xOkxccdxl              cxxc    dxd      oxd    dxl     oxd    cxx    
            ");

            Console.ForegroundColor = ConsoleColor.White;

            Console.Write(@"

                                                      Choose an option:

                                                        1. Continue
                                                  2. Restart current level
                                                         3. Quit         
                                                            
                                 
                                                         xxddxxk                                              
                                                       ;dxxddxxkxo;         ,,,,                              
                                                       lkdodkdoxkkd      ,,,,,,                               
                                                       :xxdxkdxxkko,  ,,,,                                    
                                                         lkkkkxlcc:,,,                                        
                                                     ,cdkdc::;,,;;:c;                                         
                                                   :kKXKKK0kdddxkO0KOl                                        
                                                  lKXK00KKKXXXXKKKKKKK0xo,                                    
                                                  OXXk,cKXKKKKKKXXKkkKXXXx;                                   
                                                 ;0XXd :KXKXKKK0Okx:;cloo;                                    
                                                 ,kxdc :0KOkxdolcccccc:           oxk0x                       
                                                  kxd    ,:ccccc; ,;:cc:,;cllodddkKNNNk                       
                                                           ,:ccc;  :lccclxxdolloooxKNNk                       
                                                            :cccokO0xlccccllooooold0NNk                       
                                                         colccccoddool:;:c::loodkOKXNNk                       
                                                     dx0KKkl:ccclooooolc::cokOKXNNNNNNk                       
                                                 dx0K0Oxdoc;;cc:cllllodxk0KXNNNNNNNNNNk                       
                                             dx0X0kxdolooolc::;;cldkO0XNNNNNNNNNNNNNNNk                       
                                           dXNNNOoloooooooooodxO0KXNNNNNNNNNNNNNNNNNNNk                       
                                           dNNNNKdoooloodxk0KXNNNNNNNNNNNNNNNNNNNNNNNNk                       
                                            dNNNNKkdxkO0XNNNNNNNNNNNNNNNNNNNNNNNNNNNNK                       
                                             dKXNNXKXNNNNNNNNNNNNNNNNNNNNNNNNNNNNNXXk                  
            ");
        }
    }
}
