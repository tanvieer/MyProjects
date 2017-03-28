#include<stdio.h>
#include<string.h>
#include<windows.h>
#include<time.h>
#include<stdlib.h>
#define blue {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=1);}
#define green {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=2);}
#define sky {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=3);}
#define red {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=4);}
#define pink {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=5);}
#define yellow {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=6);}
#define white {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=7);}
#define ash {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=8);}
#define blue2 {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=9);}
#define green2 {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=10);}
#define sky2 {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=11);}
#define red2 {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=12);}
#define pink2 {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=13);}
#define yellow2 {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=14);}
#define white2 {int c = 0; c <=255;c++;SetConsoleTextAttribute (hConsole, c=15);}

int add(char Q[])
{
        int a[100];
        int sum=0;
        int i=0;
        int count;

        for(count=0; Q[count]!='\0'; count++)
        {
                if(Q[count]>=48 && Q[count]<=57)
                {
                        sum=sum*10+Q[count]-48;
                        a[i]=sum;
                }

                else
                {
                        sum=0;
                        if(count!=0)
                        {
                                if(Q[count-1]>=48 && Q[count-1]<=57)
                                {
                                        i++;
                                }
                        }
                }
        }

        if(Q[strlen(Q)-1]>=48 && Q[strlen(Q)-1]<=57)
        {
                i++;
        }

        sum=0;

        for(count=0; count<i; count++)
        {
                sum=sum+a[count];
        }

        return sum;
}

int sub(char Q[])
{
        int a[100];
        int sum=0;
        int i=0;
        int count;

        for(count=0; Q[count]!='\0'; count++)
        {
                if(Q[count]>=48 && Q[count]<=57)
                {
                        sum=sum*10+Q[count]-48;
                        a[i]=sum;
                }

                else
                {
                        sum=0;
                        if(count!=0)
                        {
                                if(Q[count-1]>=48 && Q[count-1]<=57)
                                {
                                        i++;
                                }
                        }
                }
        }

        if(Q[strlen(Q)-1]>=48 && Q[strlen(Q)-1]<=57)
        {
                i++;
        }

        sum=0;

        for(count=0; count<i; count++)
        {
                if(count==2)
                {
                        break;
                }

                sum=sum+a[count];
        }

        if(strstr(Q, "from")!=NULL)
        {
                return (a[1]*2-sum);
        }

        else
        {
                return (sum-a[1]*2);
        }
}

int main()

{   HANDLE hConsole;
    hConsole = GetStdHandle(STD_OUTPUT_HANDLE);

    int i,infolen,ch;

    char info[]="My name is LITTLE BUDDY who  will give u information on ur request\nIm created and developed by TANVIR and MOBASSER\nYou can ask me anything i will try to reply u\nexample:what is your name??........................";
    infolen=strlen(info);
    for(i=0;i<=infolen;i++){
    sky2;
    printf("%c",info[i]);
    Sleep(10);
    }
    system("cls");

    char q[100];
    char n[100];
    while(1){
    Sleep(300);
    system("cls");
    red2;
    printf("Press Enter to continue, or type QUITE and then press enter to exit.\n\n");

    gets(n);strlwr(n);system("cls");
    if(strstr(n,"quite")!=NULL || strstr(n,"exit")!=NULL ||
strstr(n,"stop")!=NULL ||strstr(n,"finish")!=NULL)
        {
            sky2;printf("\n\nOk Bye Bye !!!! , have a nice day :) ");Sleep(2000);break;          // QUITE
        }
    else
    system("cls");
    white2;
    printf("What can i do for you sir , ask me or order me......\n\n");
    gets(q);
    green2;printf("\nAs you say sir..");
    for(i=0;i<8;i++)
    {
        printf("..");
        Sleep(200);
    }

    printf("\n");
    strlwr(q);
{
{            printf("\n\n");
    if(strstr(q, "+")!=NULL || strstr(q,"add")!=NULL || strstr(q,"sum")!=NULL)
            {
            printf("The resutl is = %d",add(q));                        // ADD
            getch();}
    else if(strstr(q,"minus")!=NULL || strstr(q,"subtract")!=NULL ||
strstr(q,"sub")!=NULL ||  strstr(q, "deduct")!=NULL || strstr(q,
"-")!=NULL)
            {
                printf("%d", sub(q)); getch();}
  //SUBTRACT

    else if(strstr(q,"ur name")!=NULL || strstr(q,"your name")!=NULL)
            {
             sky2;
             printf("My name is Little Buddy :) ");
             getch(); }
    // NAME
    else if(strstr(q,"birthday")!=NULL)
            {pink;
            printf("my birthday is 14.4.2014");
            getch();}
     // BIRTHDAY
    else if(strstr(q,"developer")!='\0'||strstr(q,"developer")!='\0'||strstr(q,"devloper")!='\0')
        {

         green2;printf("My developers are TANVIR ISLAM & MOBASSER AHMED.");    // DEVLOPER
             getch();
        }
                else
if(strstr(q,"developer")!='\0'||strstr(q,"developer")!='\0'||strstr(q,"creator")!='\0')
        {

         green2;printf("My creators are TANVIR ISLAM & MOBASSER AHMED.");     // CREATOR
             getch();
        }

    else if(strstr(q,"timer")!='\0'||strstr(q,"stopwatch")!='\0')
       // TIMER
        {int i=-1,j,h=0;
        for(j=0;j<=59;j++){
        if(j==0){
        i=i+1;
        if(i==60){
        h=h+1;
        i=0;
        if(h==24)
        h=-1;
        }
        }printf("hour\tmint\t\tsec\n");
        printf("%d\t%d\t\t%d\n",h,i,j);
         Sleep(1000);
         system("cls");}}
    else if(strstr(q,"what time")!='\0'||strstr(q,"time")!='\0'||strstr(q,"current time")!='\0'|| strstr(q,"what time is it")!='\0' ||strstr(q,"what the time is it")!=NULL || strstr(q,"what the time")!=NULL)
            {time_t currentTime = time(0);
       // TIME
             printf("The Current Time is %s", ctime(&currentTime));
             getch();}
    else if(strstr(q,"quite")!=NULL || strstr(q,"exit")!=NULL || strstr(q,"stop")!=NULL ||strstr(q,"finish")!=NULL)
        {
            printf("Ok Bye Bye !!!! , have a nice day :) ");Sleep(1000);break; getch();         // QUITE
        }

    else if(strstr(q,"fuck")!=NULL)
        {
            printf("Behave yourself.");getch();
               // QUITE
        }

    else if(strstr(q,"shutdown")!='\0'||strstr(q,"turn off")!='\0'||strstr(q,"off")!='\0')
        {

            printf("Do you want to shutdown your computer now (y/n)\n");                // Shutdown
            char ch;
            scanf("%c",&ch);
            if (ch == 'y')
            system("C:\\WINDOWS\\System32\\shutdown /s");
        }

    else if(strstr(q,"notepad")!='\0'){
            // NOTEPAD
            system("C:\\Windows\\System32\\notepad");
        }
    else if(strstr(q,"control")!='\0')
            // CONTROL PANAL
            system("C:\\Windows\\System32\\control");


    else if(strstr(q,"love calculator")!='\0' ||
strstr(q,"love")!=NULL)          // LOVE CALCULATOR


          {int n,m;
char name[15],pname[15];
int avg=0,q,p,i,sumname=0,sumpname=0;
system("cls");
pink2;
printf("Enter your name : ");
gets(name);
strlwr(name);
q=strlen(name);
printf("\nEnter your partner name : ");
gets(pname);
strlwr(pname);
p=strlen(pname);
for(i=0;i<q;i++)
sumname=(sumname+name[i]);
int avg1=sumname/q;
for(i=0;i<p;i++)
sumpname=(sumpname+pname[i]);
int avg2=sumpname/p;
avg=(avg1+avg2)%256;
if(avg>100)
    avg=avg/2;
if(avg>100)
    avg=avg/2;
if(avg>100)
    avg=avg/2;
if(avg<20)
    avg=avg+79;
if((avg%2)==0)
avg=avg-39;
if((avg%7)==0)
avg=avg-18;
if((avg%5)==0&&avg<56)
avg=avg+45;
system("cls");
if(strstr(name,"tanvir")!=NULL && strstr(pname,"tiha")!=NULL ||
strstr(pname,"tanvir")!=NULL && strstr(name,"tiha")!=NULL)
avg=100;
printf("\n\nYour love percentage is %d",avg);
if(avg<40)
printf("\n\nTry to Increase your love toooooooooo bad......");
if(avg>=40&&avg<=99)
printf("\n\nHmmmmm well your love is soo soo improve it.........");
if(avg>60&&avg<=90)
printf("\n\nCongtars....V.good...keep it up.");
if(avg>90&&avg<=99)
printf("\n\nWOW GREAT..........Fantastic........your next goal is to acchive full 100.......ok");
if(avg==100)
printf("\n\nPERFECT Made for each other true love .");
getch();
}


    else if(strstr(q,"calculator")!=NULL || strstr(q,"calcu")!=NULL)
            system("C:\\Windows\\System32\\calc");
    else if(strstr(q,"help")!=NULL)
            {printf("1.I can open calculator\n2.I can open CONTROL PANEL.\n3.I can open notepad\n4.I can open TIMER.\n5.I can Shut Down your pc.\n6.I can answer some question.\n7.Love Calculator");getch();}
    else if(strstr(q,"about you"))
            {printf("My name is LITTLE BUDDY who  will give u information on ur request\nIm created and developed by TANVIR and MOBASSER\nYou can ask me anything i will try to reply u\nexample:what is your name??................\n\n\n1.I can open calculator\n2.I can open CONTROL PANEL.\n3.I can open notepad\n4.I can open TIMER.\n5.I can Shut Down your pc.\n6.I can answer some question.");getch();}





    else
            {printf("Sorry can't understand , will you repeat please.");getch();}

}
}
}}
