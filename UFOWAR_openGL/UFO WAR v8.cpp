#include <iostream>
#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <windows.h>
#include <string.h>
#include <string>

#include <sstream>

#define SSTR( x ) static_cast< std::ostringstream & >( \
        ( std::ostringstream() << std::dec << x ) ).str()

using namespace std;

#include <stdarg.h>                       // Header File For Variable Argument Routines   ( ADD )
#include <gl\gl.h>                        // Header File For The OpenGL32 Library
#include <gl\glu.h>                       // Header File For The GLu32 Library
//#include <gl\glaux.h>
#include <GL/glut.h>


float _angle = 0.0;
float _cameraAngle = 0.0;
float _ang_tri = 0.0;
float zex = -100.0;
float viewCam = 0;

bool rotateON = false , left1 = true , pause = false;
float angleCAM = 0.0;   /// for rotation

float moveUfo =0.0, moveCam =0.0;

float SCORE = 0.0;
float LIFE = 100;

float fire1 =0.0;
bool fire = false;
//----------------------------------------------collision variable ------------------------------------------------------------

float objectStartPosition = -200;
float car1X = 2.0;
float carY = -.8;
float car1Z = 0.0;
float collideposition = 0;

float objectStartPosition2 = -150;
float car2X = 0.0;
float car2Z = 0.0;
float collideposition2 = 0;

float objectStartPosition3 = -100;
float car3X = -2.0;
float car3Z = 0.0;
float collideposition3 = 0;
float bullet_size = .75;
float speed1 = 54 , speed2 = 100;
bool heal = false;
float heal1X = 0.0 , heal2X = 2.0, heal3X = -2.0;
int heal_check = 1;




//----------------------------------------------collision variable ------------------------------------------------------------

//=================Game Over Text=====================================================================================
char quote[6][80];
int numberOfQuotes = 0;
GLfloat UpwardsScrollVelocity = -10.0;
float view = 10.0;
char numberArray[2];
//================================================================================================================
//================================================================Light start=====================================================

void light_red(void)
{
    GLfloat mat_specular[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { .1, .1, 1, 0 };
    GLfloat white_light[] = { 1, 0, 0, 0 };
    GLfloat mat_ambiant[]= {0.2f, 0.2f, 0.2f, 1.0f};


// glClearColor (0.4,0.9,0.9 ,0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    //glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void light_yellow(void)
{
    GLfloat mat_specular[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { .1, .1, 1, 0 };
    GLfloat white_light[] = { 1, 1, 0, 0 };

// glClearColor (0.4,0.9,0.9 ,0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    // glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void light_black(void)
{
    GLfloat mat_specular[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { .1, .1, 1, 0 };
    GLfloat white_light[] = { 0, 0, 0, 0 };

// glClearColor (0.4,0.9,0.9 ,0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void light_white(void)
{
    GLfloat mat_specular[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { .1, .1, 1, 0 };
    GLfloat white_light[] = { 1, 1, 1, 0 };

// glClearColor (0.4,0.9,0.9 ,0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    // glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void light_blue(void)
{
    GLfloat mat_specular[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { .1, .1, 1, 0 };
    GLfloat white_light[] = { 0, 0, 1, 0 };

// glClearColor (0.4,0.9,0.9 ,0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    // glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void light_wood_tree(void)
{
    GLfloat mat_specular[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { .1, .1, 1, 0 };
    GLfloat white_light[] = { 0.9,0.3,0 };


// glClearColor (0.4,0.9,0.9 ,0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    // glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void light_green_tree(void)
{
    GLfloat mat_specular[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { .1, .1, 1, 0 };
    GLfloat white_light[] = { 0,1,0.3,1 };


// glClearColor (0.4,0.9,0.9 ,0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    // glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void light_purple(void)
{
    GLfloat mat_specular[] = { 0.9,0.3,0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { .1, .1,.1, 0 };
    GLfloat white_light[] = {1.0, 0.0, 1.0 };


// glClearColor (0.4,0.9,0.9 ,0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void init(void)
{
    GLfloat mat_specular[] = { .20, .20, .20, 0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { -.9, 1, .80, 0.0 };
    GLfloat white_light[] = { 0.20, 0.60, 1.0, 0.0 };

    // glClearColor (0.0, 0.0, 0.0, 0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    // glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void light2(void)
{
    GLfloat mat_specular[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { -1.0, 0.1, .50, 0.0 };
    GLfloat white_light[] = { 0.20, 0.60, 1.0, 0.0 };

    // glClearColor (0.0, 0.0, 0.0, 0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    // glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void light3(void)
{
    GLfloat mat_specular[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { .1, .1, 1, 0 };
    GLfloat white_light[] = { 9, 9, 0, 10 };

    //glClearColor (0.0, 0.0, 0.0, 0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    // glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void light1(void)
{
    GLfloat mat_specular[] = { 1.0, 1.0, 1.0, 1.0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { 0, .8, .8, 0.0 };
    GLfloat white_light[] = { 0.20, 0.60, 1.0, 0.0  };

    //glClearColor (0.0, 0.0, 0.0, 0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    //glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}
void light_orange(void)
{
    GLfloat mat_specular[] = { 0.9,0.3,0 };
    GLfloat mat_shininess[] = { 100.0 };
    GLfloat light_position[] = { .1, .1,.1, 0 };
    GLfloat white_light[] = {1.0 ,0.5, 0.0,0};


// glClearColor (0.4,0.9,0.9 ,0.0);
    glShadeModel (GL_SMOOTH);

    glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
    glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
    glLightfv(GL_LIGHT0, GL_POSITION, light_position);

    glLightfv(GL_LIGHT0, GL_DIFFUSE, white_light);
    glLightfv(GL_LIGHT0, GL_SPECULAR, white_light);

    glEnable(GL_LIGHTING);
    glEnable(GL_LIGHT0);
    glEnable(GL_DEPTH_TEST);
}


void initRendering()
{
    glEnable(GL_DEPTH_TEST);
}

//=========================================================================Light end===============================================================


void drawtext(const char *text,int length,int x,int y)
{
    glMatrixMode(GL_PROJECTION);
    double* matrix=new double[16];
    glGetDoublev(GL_PROJECTION_MATRIX,matrix);
    glLoadIdentity();
    glOrtho(0,800,0,600,-5,5);
    glMatrixMode(GL_MODELVIEW);
    glPushMatrix();
    glLoadIdentity();
    glRasterPos2i(x,y);
    for(int i=0; i<length; i++)
    {
        glutBitmapCharacter(GLUT_BITMAP_9_BY_15,(int)text[i]);
    }
    glPopMatrix();
    glMatrixMode(GL_PROJECTION);
    glLoadMatrixd(matrix);
    glMatrixMode(GL_MODELVIEW);

}


void drawHealthBar()
{

    if (LIFE <= 10)
    {
        glBegin(GL_QUADS);
        glColor3f(1, 0, 0);

        glVertex2f( -3,  0);
        glVertex2f( -2.8,  0);
        glVertex2f( -2.8,  .2);
        glVertex2f( -3,  .2);
        glEnd();
    }


    else if (LIFE <= 20)
    {
        glBegin(GL_QUADS);
        glColor3f(1, 0, 0);

        glVertex2f( -3,  0);
        glVertex2f( -2.1,  0);
        glVertex2f( -2.1,  .2);
        glVertex2f( -3,  .2);
        glEnd();
    }

    else if (LIFE <= 30)
    {
        glBegin(GL_QUADS);
        glColor3f(1, 1, 0);

        glVertex2f( -3,  0);
        glVertex2f( -1.4,  0);
        glVertex2f( -1.4,  .2);
        glVertex2f( -3,  .2);
        glEnd();
    }


    else if (LIFE <= 40)
    {
        glBegin(GL_QUADS);
        glColor3f(1, 1, 0);

        glVertex2f( -3,  0);
        glVertex2f( -.7,  0);
        glVertex2f( -.7,  .2);
        glVertex2f( -3,  .2);
        glEnd();
    }

    else if (LIFE <= 50)
    {
        glBegin(GL_QUADS);
        glColor3f(0, 1, 1);

        glVertex2f( -3,  0);
        glVertex2f( 0,  0);
        glVertex2f( 0,  .2);
        glVertex2f( -3,  .2);
        glEnd();
    }

    else if (LIFE <= 60)
    {
        glBegin(GL_QUADS);
        glColor3f(.5, .1, .5);

        glVertex2f( -3,  0);
        glVertex2f( 0.9,  0);
        glVertex2f( 0.9,  .2);
        glVertex2f( -3,  .2);
        glEnd();
    }

    else if (LIFE <= 70)
    {
        glBegin(GL_QUADS);
        glColor3f(0, 0, 1);

        glVertex2f( -3,  0);
        glVertex2f( 1.6,  0);
        glVertex2f( 1.6,  .2);
        glVertex2f( -3,  .2);
        glEnd();
    }

    else if (LIFE <= 80)
    {
        glBegin(GL_QUADS);
        glColor3f(0, 0, 1);

        glVertex2f( -3,  0);
        glVertex2f( 2.3,  0);
        glVertex2f( 2.3,  .2);
        glVertex2f( -3,  .2);
        glEnd();
    }

    else if (LIFE <=90)
    {

        glBegin(GL_QUADS);
        glColor3f(0, 1, 0);

        glVertex2f( -3,  0);
        glVertex2f( 2.5,  0);
        glVertex2f( 2.5,  .2);
        glVertex2f( -3,  .2);
        glEnd();
    }


    else if (LIFE <=100)
    {

        glBegin(GL_QUADS);
        glColor3f(0, 1, 0);

        glVertex2f( -3,  0);
        glVertex2f( 3,  0);
        glVertex2f( 3,  .2);
        glVertex2f( -3,  .2);
        glEnd();
    }

}


char* toArray(int number)
{
    int n = log10(number);
    int i;
    char numberArray[200];
    for ( i = n; number != 0; i--, number /= 10 )
    {
        numberArray[i] = (char)((number % 10) + '0');
        //cout << (char)((number % 10) + '0');
    }
    //cout << "\n";
    numberArray[n+1] = '\0';
    //printf("sknfk  %s   skdf\n", numberArray);
    return numberArray;
}


void RenderToDisplay()
{
    int l, lenghOfQuote, i;

    glTranslatef(0.0, -100, UpwardsScrollVelocity);
    glRotatef(-20, 1.0, 0.0, 0.0);
    glScalef(0.1, 0.1, 0.1);



    for (l = 0; l<numberOfQuotes; l++)
    {
        lenghOfQuote = (int)strlen(quote[l]);
        glPushMatrix();
        glTranslatef(-(lenghOfQuote * 37), -(l * 200), 0.0);
        for (i = 0; i < lenghOfQuote; i++)
        {
            glColor3f((UpwardsScrollVelocity / 10) + 300 + (l * 10), (UpwardsScrollVelocity / 10) + 300 + (l * 10), 0.0);
            glutStrokeCharacter(GLUT_STROKE_ROMAN, quote[l][i]);

        }
        glPopMatrix();
    }

}


void myDisplayFunction(void)
{
    glClear(GL_COLOR_BUFFER_BIT);
    glLoadIdentity();
    gluLookAt(0.0, 30.0, 100.0, 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);
    RenderToDisplay();
    glutSwapBuffers();
}


void reshape(int w, int h)
{
    glViewport(0, 0, w, h);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluPerspective(60, 1.0, 1.0, 3200);
    glMatrixMode(GL_MODELVIEW);
}

void timeTick(void)
{
    if (UpwardsScrollVelocity< -600)
        view -= 0.000011;
    if (view < 0)
    {
        view = 20;
        UpwardsScrollVelocity = -10.0;
    }
    //  exit(0);
    UpwardsScrollVelocity -= 0.1;
    glutPostRedisplay();

}

int Gameover(char *a)
{
    strcpy(quote[0], "Game Over");
    strcpy(quote[1], "Score Is");
    strcpy(quote[2], a);
    //strcpy(quote[3], '1');
    numberOfQuotes = 3;

    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(1360, 750);
    glutCreateWindow("Game Result");
    glClearColor(0.0, 0.0, 0.0, 1.0);
    glLineWidth(3);

    glutDisplayFunc(myDisplayFunction);
    glutReshapeFunc(reshape);
    glutIdleFunc(timeTick);
    glutMainLoop();

    return 0;
}





















//Called when the window is resized
void handleResize(int w, int h)
{
    glViewport(0, 0, w, h);
    glMatrixMode(GL_PROJECTION);
    glLoadIdentity();
    gluPerspective(45.0, (double)w / (double)h, 1.0, 200.0);

}

void round_tree()
{

    ///lamp post///
///main pole of the lamp post///
    glPushMatrix();
        glPushMatrix();
        ///init();
        light_wood_tree();
        //glColor3f(0.9,0.3,0);
        glTranslatef(0,0,0);
        glRotatef(90,1,0,0);
        glScalef(3,.75,20);
        glutSolidTorus(.03,.03,90,100);
        glPopMatrix();

        ///tree er top///

        glPushMatrix();
        ///init();
        light_green_tree();
        //glColor3f(0,1,0.3);
        glTranslatef(0,.6,0);
        glScalef(6,6,6);
        glutSolidSphere(.1,30,30);
        glPopMatrix();
        glDisable(GL_LIGHT0);
        glDisable(GL_LIGHTING);
    glPopMatrix();

}
void cone_tree()
{
    ///tree er botton///
    glPushMatrix();
    glPushMatrix();
    ///init();
    //glColor3f(0.9,0.3,0);
    light_wood_tree();
    glTranslatef(0,0,0);
    glRotatef(90,1,0,0);
    glScalef(2,.75,15);
    glutSolidTorus(.03,.03,90,100);
    glPopMatrix();

    ///tree er top///

    glPushMatrix();
    ///init();
    //glColor3f(0,1,0.3);
    light_green_tree();
    glTranslatef(0,.3,0);
    glRotatef(90,-1,0,0);
    glutSolidCone(.6,1.5,30,30);
    glPopMatrix();
    glDisable(GL_LIGHT0);
    glDisable(GL_LIGHTING);
    glPopMatrix();
}

void road()
{
    glPushMatrix();

    //=======================================================road scene======================================

    glPushMatrix();

    glBegin(GL_QUADS);

    glColor3f(0.0,1.0,0.0);

    int ym = -2;

    glVertex3f(-50, ym, -300.0);

    glVertex3f(50.0, ym, -300.0);

    glVertex3f(50.0, ym,100.0);

    glVertex3f(-50, ym, 100.0);

    glEnd();
    glPopMatrix();   //==========================================================plane=================


    glPushMatrix();
    glTranslatef(10,0,0);
    glTranslatef(0,-1,0);
    glTranslatef(0,0,-30);

    cone_tree();
    glTranslatef(-20,0,0);
    round_tree();

    glTranslatef(0,0,50);
    glTranslatef(0,0,50);
    cone_tree();
    glTranslatef(20,0,0);
    round_tree();



    glPopMatrix();

//==========================================================end scene=============================

    //=====================================================road start================================================
    glPushMatrix();
    glTranslatef(0,-1.2,0);
    glTranslatef(0,0,5);
    glScalef(1,.1,1);
    glScalef(8,1,250);

    glColor3f(.4,.4,.4);
    //        light_ash_road();
    glColor3f(.5,.5,.5);
    glutSolidCube(1);
    //glDisable(GL_LIGHT0);
    glPopMatrix();

    //================================================heal ============================================

        if(heal){
            glPushMatrix();
            glTranslatef(0,-.7,0);
            if(heal_check == 1){
                glColor4f(1,1,0,.5);
                glTranslatef(heal1X,0,0);
            }

            if(heal_check == 2){
                glColor4f(1,.5,1,.5);
                glTranslatef(heal2X,0,0);
            }

            if(heal_check == 3){
                glColor4f(0,1,.5,.5);
                glTranslatef(heal3X,0,0);
            }



                glutSolidCube(.8); // ========================================= heal box================
            glPopMatrix();

        }

    //=======================================================road print==================================================

    glPushMatrix();
    glTranslatef(0,-1.199,0);

    glColor3f(1,1,1);



    //	light_white();
    glScalef(.70,.2,7);

    glTranslatef(0.0,0.0,-15);
    for(int i = 0; i < 10 ; i++)      //Road Print
    {
        glutSolidCube(.5);
        glTranslatef(0.0,0.0,3);
    }

    glPopMatrix();

//=====================================================road end================================================


    glPopMatrix();

}

void lampPost()
{

    glPushMatrix();

    glPushMatrix();
    init();
    //glColor3f(0.0,0.0,.5);
    glTranslatef(0,0,0);
    glRotatef(90,1,0,0);
    glScalef(.9,.95,30);
    glutSolidTorus(.03,.03,90,100);

    glPopMatrix();

    ///hand of lamp post///
    glPushMatrix();
    light2();
    //glColor3f(0.0,0.0,.5);
    glTranslatef(-.18,.83,0);
    glRotatef(90,0,1,0);
    glScalef(.9,.5,10);
    glutSolidTorus(.03,.03,90,90);
    glPopMatrix();

    ///light blub hanger stick///
    glPushMatrix();
    light1();
    //glColor3f(0.0,0.0,.5);

    glTranslatef(-.40,.75,0);
    glRotatef(90,1,0,0);
    glScalef(.3,.9,5);
    glutSolidTorus(.03,.03,90,90);
    glPopMatrix();

    ///light blub///
    glPushMatrix();
    light3();
    //glColor3f(1.0,1.0,.0);

    glTranslatef(-.40,.60,0);
    glutSolidSphere(.15,20,20);
    glPopMatrix();
    glDisable(GL_LIGHT0);
    glDisable(GL_LIGHTING);
    glPopMatrix();
}

void lampPost2()
{
    glPushMatrix();

    glPushMatrix();
    init();
    //glColor3f(0.0,0.0,.5);
    glTranslatef(0,0,0);
    glRotatef(90,1,0,0);
    glScalef(.9,.95,30);
    glutSolidTorus(.03,.03,90,100);

    glPopMatrix();

    ///hand of lamp post///
    glPushMatrix();
    light2();
    //glColor3f(0.0,0.0,.5);
    glTranslatef(-.18,.83,0);
    glRotatef(90,0,1,0);
    glScalef(.9,.5,10);
    glutSolidTorus(.03,.03,90,90);
    glPopMatrix();

    ///light blub hanger stick///
    glPushMatrix();
    light1();
    //glColor3f(0.0,0.0,.5);

    glTranslatef(-.40,.75,0);
    glRotatef(90,1,0,0);
    glScalef(.3,.9,5);
    glutSolidTorus(.03,.03,90,90);
    glPopMatrix();

    ///light blub///
    glPushMatrix();
    light3();
    //glColor3f(1.0,1.0,.0);

    glTranslatef(-.40,.60,0);
    glutSolidSphere(.15,20,20);
    glPopMatrix();
    glDisable(GL_LIGHT0);
    glDisable(GL_LIGHTING);
    glPopMatrix();
}

void  lamp()
{

    glColor3f(1,1,1);
    glTranslatef(-3.25,0,0);
    glTranslatef(0,0,-190);
    for(int i=0; i < 3; i++)
    {
        glTranslatef(6.5,0,0);
        lampPost();
        glTranslatef(-6.5,0,0);
        glRotatef(180,0,1,0);
        lampPost2();
        glRotatef(180,0,1,0);
        glTranslatef(0,0,110);
    }

}

void car_3D_red()
{
    //glRotatef(45,0,1,0);
    glTranslatef(0,-.2,0);
    glScalef(.8,.8,.5);

    glPushMatrix();
    ///main body//
    glPushMatrix();
    glTranslatef(0,0,-.4);
    //glColor3f(1,0,0);
    light_red();
    glScalef(1,.4,2);
    glutSolidCube(1);
    glPopMatrix();


    ///car er roof//
    glPushMatrix();
    glTranslatef(0,.3,-.4);
    //glColor3f(0,0,1);
    light_blue();
    glScalef(2,.4,2);
    glutSolidCube(.5);
    glPopMatrix();

    ///windshild//
    glPushMatrix();
    glTranslatef(0,.3,.13);
    glRotatef(25,-1,0,0);
    light_white();
    //glColor3f(.9,.9,.9);
    glScalef(2,.4,.1);
    glutSolidCube(.5);
    glPopMatrix();



    ///car er light
    glPushMatrix();
    glTranslatef(-0.2,0,0.6);
    light_yellow();
    //glColor3f(1,1,0);
    glRotatef(90,0,1,0);
    //glScalef(1,.5,1);
    glutSolidSphere(.1,20,20);
    glPopMatrix();
    ///car er light right
    glPushMatrix();
    glTranslatef(0.2,0,0.6);
    light_yellow();
    //glColor3f(1,1,0);
    glRotatef(90,0,1,0);
    //glScalef(1,.5,1);
    glutSolidSphere(.1,20,20);
    glPopMatrix();
    ///car er wheel front//

    glPushMatrix();
    //glColor3f(0.01,0.01,0.01);
    light_black();
    glTranslatef(-0.5,-.2,.1);
    glRotatef(90,0,1,0);
    glutSolidTorus(.07,.15,20,30);
    glPopMatrix();

    ///car wheel front//
    glPushMatrix();
    light_black();
    //glColor3f(0.01,0.01,0.01);
    glTranslatef(0.5,-.2,.1);
    glRotatef(90,0,1,0);
    glutSolidTorus(.07,.15,20,30);
    glPopMatrix();

    ///car wheel back///
    glPushMatrix();
    light_black();
    //glColor3f(0.01,0.01,0.01);
    glTranslatef(-0.5,-.2,-.85);
    glRotatef(90,0,1,0);
    glutSolidTorus(.07,.15,20,30);
    glPopMatrix();

    ///car wheel back///
    glPushMatrix();
    light_black();
    //glColor3f(0.01,0.01,0.01);
    glTranslatef(0.5,-.2,-.85);
    glRotatef(90,0,1,0);
    glutSolidTorus(.07,.15,20,30);
    glPopMatrix();
    glDisable(GL_LIGHT0);
    glDisable(GL_LIGHTING);
    //glDisable(GL_DEPTH_TEST);

//	   glEnable(GL_LIGHTING);
//   glEnable(GL_LIGHT0);
//   glEnable(GL_DEPTH_TEST);

    glPopMatrix();

}

void car_3D_pink()
{
    //glRotatef(45,0,1,0);
    glTranslatef(0,-.2,0);
    glScalef(.8,.8,.5);

    glPushMatrix();
    ///main body//
    glPushMatrix();
    glTranslatef(0,0,-.4);
    //glColor3f(1,0,0);
    //light_red();
    light_purple();
    glScalef(1,.4,2);
    glutSolidCube(1);
    glPopMatrix();


    ///car er roof//
    glPushMatrix();
    glTranslatef(0,.3,-.4);
    //glColor3f(0,0,1);
    light_blue();
    glScalef(2,.4,2);
    glutSolidCube(.5);
    glPopMatrix();

    ///windshild//
    glPushMatrix();
    glTranslatef(0,.3,.13);
    glRotatef(25,-1,0,0);
    light_white();
    //glColor3f(.9,.9,.9);
    glScalef(2,.4,.1);
    glutSolidCube(.5);
    glPopMatrix();



    ///car er light
    glPushMatrix();
    glTranslatef(-0.2,0,0.6);
    light_yellow();
    //glColor3f(1,1,0);
    glRotatef(90,0,1,0);
    //glScalef(1,.5,1);
    glutSolidSphere(.1,20,20);
    glPopMatrix();
    ///car er light right
    glPushMatrix();
    glTranslatef(0.2,0,0.6);
    light_yellow();
    //glColor3f(1,1,0);
    glRotatef(90,0,1,0);
    //glScalef(1,.5,1);
    glutSolidSphere(.1,20,20);
    glPopMatrix();
    ///car er wheel front//

    glPushMatrix();
    //glColor3f(0.01,0.01,0.01);
    light_black();
    glTranslatef(-0.5,-.2,.1);
    glRotatef(90,0,1,0);
    glutSolidTorus(.07,.15,20,30);
    glPopMatrix();

    ///car wheel front//
    glPushMatrix();
    light_black();
    //glColor3f(0.01,0.01,0.01);
    glTranslatef(0.5,-.2,.1);
    glRotatef(90,0,1,0);
    glutSolidTorus(.07,.15,20,30);
    glPopMatrix();

    ///car wheel back///
    glPushMatrix();
    light_black();
    //glColor3f(0.01,0.01,0.01);
    glTranslatef(-0.5,-.2,-.85);
    glRotatef(90,0,1,0);
    glutSolidTorus(.07,.15,20,30);
    glPopMatrix();

    ///car wheel back///
    glPushMatrix();
    light_black();
    //glColor3f(0.01,0.01,0.01);
    glTranslatef(0.5,-.2,-.85);
    glRotatef(90,0,1,0);
    glutSolidTorus(.07,.15,20,30);
    glPopMatrix();
    glDisable(GL_LIGHT0);
    glDisable(GL_LIGHTING);
    //glDisable(GL_DEPTH_TEST);

//	   glEnable(GL_LIGHTING);
//   glEnable(GL_LIGHT0);
//   glEnable(GL_DEPTH_TEST);

    glPopMatrix();

}

void carRun()
{

    glPushMatrix();
    glTranslatef(0,0,objectStartPosition);
    car1Z = objectStartPosition;

    glTranslatef(0,carY,0);
    glTranslatef(0,0,3);
    glColor3f(1,0,0);
    glTranslatef(car1X,0.0,0);

    glTranslatef(0.0,0.0,-100);
    glTranslatef(0,.15,3);
    car_3D_red();                              //CAR1
    glTranslatef(0.0,0.0,70);

    glPopMatrix();



    glPushMatrix();                                     //Car 2 start
    glTranslatef(0,0,objectStartPosition2);
    car2Z = objectStartPosition2;

    glTranslatef(0,carY,0);
    glTranslatef(0,0,5);
    glColor3f(1,0,0);
    glTranslatef(car2X,0.0,0);

    glTranslatef(0.0,0.0,-100);
    // glTranslatef(0.0,0.0,140);

    // glScalef(1,1,4);
    // glScalef(1,.5,1);
    glTranslatef(0,.15,3);
    car_3D_pink();                                //CAR2

    glTranslatef(0.0,0.0,70);

    glPopMatrix();



    glPushMatrix();                                     //Car 3 start
    glTranslatef(0,0,objectStartPosition3);
    car3Z = objectStartPosition3;

    glTranslatef(0,carY,0);
    glTranslatef(0,0,5);
    glColor3f(1,0,0);
    glTranslatef(car3X,0.0,0);

    glTranslatef(0.0,0.0,-100);

    glTranslatef(0,.15,3);
    car_3D_red();                                 //CAR3

    glTranslatef(0.0,0.0,70);

    glPopMatrix();

}

void UFO()
{
    glPushMatrix();

    glScalef(1.3,.8,1.3);
    glRotatef(180,0,1,0);
    glRotatef(-45,1,0,0);

    glPushMatrix();
//		   init();
    //glColor4f(1,0,0,.5);
    light_red();
    glRotatef(120,1,0,0);
    glScalef(1,1,1);
    glutSolidTorus(.25,.5,100,100);
    //glDisable(GL_LIGHT0);
    glPopMatrix();


    glPushMatrix();
//		   light3();
    //glColor4f(1,1,0,.5);
    light_yellow();
    glTranslatef(0,.1,0);
    glScalef(1,1.1,1);
    glutSolidSphere(.5,30,30);

    //glDisable(GL_LIGHT0);
    glPopMatrix();


    glPopMatrix();


    // glutSwapBuffers();

}

void UFO_Purple()
{
    glPushMatrix();

    glScalef(1.3,.8,1.3);
    glRotatef(180,0,1,0);
    glRotatef(-45,1,0,0);

    glPushMatrix();
//		   init();
    //glColor4f(1,0,0,.5);
    light_blue();
    glRotatef(120,1,0,0);
    glScalef(1,1,1);
    glutSolidTorus(.25,.5,100,100);
    //glDisable(GL_LIGHT0);
    glPopMatrix();


    glPushMatrix();
//		   light3();
    //glColor4f(1,1,0,.5);
    light_purple();
    glTranslatef(0,.1,0);
    glScalef(1,1.1,1);
    glutSolidSphere(.5,30,30);

    //glDisable(GL_LIGHT0);
    glPopMatrix();


    glPopMatrix();


    // glutSwapBuffers();

}


void checkCollision()
{
//    cout<<"bullet X = "<< (moveUfo) << " Bullet Z = " << fire1 <<"  collide pos = "<<collideposition2<<endl;
//    cout<<endl;
//    cout<<"Car2 X = "<< car2X <<"  Car2 Z =" << car2Z;
//    cout<<endl;
//    cout<<endl;

    if((car1Z ==94 && moveUfo <=-2.5) && !pause )   // collide with car ufo
    {
        LIFE -= 9;
        cout << "SCORE = " << SCORE<<endl;
        cout << "LIFE = " << LIFE<<endl;
        cout<<endl;
    }

    if((car2Z ==94 && moveUfo >= car2X-1.5 && moveUfo <= car2X+1.5 ) && !pause )   // collide with car ufo
    {
        LIFE -= 9;
        cout << "SCORE = " << SCORE<<endl;
        cout << "LIFE = " << LIFE<<endl;
        cout<<endl;
    }

    if((car3Z ==94 && moveUfo >= -2*car3X-1.5 && moveUfo <= -2*car3X+1.5 ) && !pause )   // collide with car ufo
    {
        LIFE -= 9;
        cout << "SCORE = " << SCORE<<endl;
        cout << "LIFE = " << LIFE<<endl;
        cout<<endl;
    }





    if((collideposition <= car1Z && collideposition+2 >= car1Z && collideposition !=0 && (-1*moveUfo) >= (2*car1X)-bullet_size && (-1*moveUfo) <= (2*car1X)+bullet_size ) && !pause )    // collide with car bullet
    {
        //pause = true;
        objectStartPosition = -250;
        fire1 = 0.0;
        fire = false;
        collideposition = 0;
        SCORE++;
        cout << "SCORE = " << SCORE<<endl;
        cout << "LIFE = " << LIFE<<endl;
        cout<<endl;
    }







    if((collideposition2 <= car2Z && collideposition2+2 >= car2Z && collideposition2 !=0 && (-1*moveUfo) >= (2*car2X)-bullet_size && (-1*moveUfo) <= (2*car2X)+bullet_size ) && !pause )    // collide with car bullet
    {
        objectStartPosition2 = -150;
        fire1 = 0.0;
        fire = false;
        collideposition2 = 0.0;
        SCORE++;
        cout << "SCORE = " << SCORE<<endl;
        cout << "LIFE = " << LIFE<<endl;
        cout<<endl;
    }



    if ( (collideposition3 <= car3Z && collideposition3+2 >= car3Z && collideposition3 !=0 && (-1*moveUfo) >= (2*car3X)-bullet_size && (-1*moveUfo) <= (2*car3X)+bullet_size ) && !pause )    // collide with car bullet
    {
        objectStartPosition3 = -180;
        fire1 = 0.0;
        fire = false;
        collideposition3 = 0.0;
        SCORE++;
        cout << "SCORE = " << SCORE<<endl;
        cout << "LIFE = " << LIFE<<endl;
        cout<<endl;
    }
    if( ( car1Z == 94 || car2Z == 94 || car3Z == 94) && !pause ) {

        LIFE -=1;
    }


    if(( heal && zex == 0 && (moveUfo >- heal_check && moveUfo < heal_check) && heal_check == 1 ) && !pause )   // healing food
    {
       // pause = true;
        heal = false;
        LIFE += 10;
        //cout <<heal_check << "  " << moveUfo<<endl;
    }

    else if(( heal && zex == 0 && (moveUfo <-4 && moveUfo > -5)  && heal_check == 2) && !pause )   // healing food
    {
       // pause = true;
        heal = false;
        LIFE += 15;
       // cout <<heal_check << "  " << moveUfo<<endl;
    }

    else if(( heal && zex == 0 && (moveUfo <=5 && moveUfo >= 4)  && heal_check == 3) && !pause )   // healing food
    {
       // pause = true;
        heal = false;
        LIFE += 20;
        //cout <<heal_check << "  " << moveUfo<<endl;
    }

    if(LIFE < 50 && LIFE >= 45) {
        heal = true;
        heal_check = 2;
        //cout <<heal_check << "  " << moveUfo<<"heal x2 = "<<heal2X<<endl;
    }

    else if(LIFE < 20 ) {
        heal = true;
        heal_check = 3;
        //cout <<heal_check << "  " << moveUfo<<"heal x3 = "<<heal3X<<endl;
    }

    else if(LIFE < 80 && LIFE >= 75) {
        heal = true;
        heal_check = 1;
    }

    else heal = false;



    if( LIFE < 1)
    {
        //SCORE = 20;
        // printf("%s\n", toArray(SCORE));
        Gameover(toArray(SCORE));
    }

}

void drawScene()
{
    glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT);
    glClearColor (0.4,0.9,0.9 ,0.0);

    glMatrixMode(GL_MODELVIEW); //Switch to the drawing perspective
    glLoadIdentity(); //Reset the drawing perspective
    glRotatef(-_cameraAngle, 0.0, 1.0, 0.0); //Rotate the camera
    glTranslatef(0.0, 0.0, -7.0); //Move forward 5 units

    glPushMatrix();
    glColor3f(1,0,0);

    int i = SCORE;
    string s = SSTR( i );
    string text;

    text="Your Score is: " + s;
    drawtext(text.data(),text.size(),680,565);

    i = LIFE;
    s = SSTR( i );

    text="|| Health: "+s;
    drawtext(text.data(),text.size(),90,565);

    if(SCORE < 10)
        text="Level: 1";
    else if(SCORE < 40)
        text="Level: 2";
    else if(SCORE < 60)
        text="Level: 3";
    else if(SCORE < 80)
        text="Level: 4";
    else if(SCORE < 100)
        text="Level: 5";
    else if(SCORE < 110)
        text="Level: 6";
    else if(SCORE < 150)
        text="Level: 7";
    else if(SCORE < 200)
        text="Level: 8";
    else if(SCORE < 250)
        text="Level: 9";
    else if(SCORE < 300)
        text="Level: 10";
    else text="WINNER";
        drawtext(text.data(),text.size(),40,565);

    text="--------------------";
    drawtext(text.data(),text.size(),680,555);


    text="Move Left  : a ";
    drawtext(text.data(),text.size(),680,530);
    text="Move Right : d ";
    drawtext(text.data(),text.size(),680,510);
    text="Fire       : space";
    drawtext(text.data(),text.size(),680,490);
    text="Pause/Play : p";
    drawtext(text.data(),text.size(),680,470);

    text="Speed Down : -";
    drawtext(text.data(),text.size(),680,450);

    text="Speed Up   : +";
    drawtext(text.data(),text.size(),680,430);

    text="Speed      : "+SSTR( 104-speed1 )+"Kmph";
    drawtext(text.data(),text.size(),680,410);






    glTranslatef(0.0, 2.5, 0.0);
    drawHealthBar();
    glPopMatrix();


    glTranslatef(0.0, -0.5, 0.0);



    glTranslatef(moveCam,0.0,0.0);

//===============================================================================


    glRotatef(-3, 1.0, 0.0, 0.0);
    glRotatef(viewCam, 0.0, 1.0, 0.0);
    glRotatef(angleCAM, 0.0, 1.0, 0.0);

    glPushMatrix();
    //sky();                             //      Star


    //=================================================ufo===================================

    glTranslatef(0,-.63,0);
    glTranslatef(0,0,1);
    glRotatef(180, 0.0, 1.0, 0.0);
    glScalef(.5,.5,.5);
    // robot();
    glTranslatef(moveUfo,0.0,0.0);
    //cout<<" move ufo = " <<moveUfo<<endl;
    if(SCORE < 10)
        UFO();
    else UFO_Purple();

    glPushMatrix();



    //glTranslatef(-moveUfo,0.0,0.0);
    if(fire)                   //=====================================================fire sphare ball
    {

//        light_red();
        glColor3f(1.0,0.0,0.0);
        glTranslatef(0.0,0.0,fire1);
        glutSolidSphere(bullet_size-.55,30,30);
        //glDisable(GL_LIGHT0);
    }

    glPopMatrix();

    checkCollision();



//==============================================================ufo end==============================
    glPopMatrix();


//=====================================================cars======================================

    glPushMatrix();
    carRun();
    glPopMatrix();

//===================================================cars========================================

//=========================================Back Ground===================================================

    glTranslatef(0.0, 0.0, zex); // start


    road();

    lamp();

//=============================================Habi jabi for test============================================================




    glPopMatrix();


    glutSwapBuffers();
}

void update(int value)
{

    if(!pause)
    {
        if(SCORE == 20 && speed1 > 25) speed1 = 25;

        zex += .5;
        if(zex > 3) zex = -100;


        if(fire )
        {
            fire1 +=2;
            if(fire1 > 80)
            {
                fire1 = 0.0;
                fire = false;
                collideposition = 0.0;
                collideposition2 = 0.0;
                collideposition3 = 0.0;
            }
        }


        if(!pause)                                               // car run
        {
            objectStartPosition += 2;
            if(objectStartPosition > 150) objectStartPosition = -200;

            objectStartPosition2 += 2;
            if(objectStartPosition2 > 150) objectStartPosition2 = -150;

            objectStartPosition3 += 2;
            if(objectStartPosition3 > 150) objectStartPosition3 = -250;
        }


    }

    if(rotateON && left1)
    {
        angleCAM +=.5;
        if (angleCAM > 360)
        {
            angleCAM -= 360;
        }
    }
    if(rotateON && !left1)
    {
        angleCAM -=.5;
        if (angleCAM < 0)
        {
            angleCAM += 360;
        }
    }

    glutPostRedisplay();
    glutTimerFunc(speed1, update, 0);

}

void keyboard(unsigned char key, int x, int y)
{
    // cout<< key<<" ";


    if( key == 'q' || key == 'Q' )
    {
        exit(0);
    }


    if( ( key == 'a' || key == 'A' ) &&!pause )
    {
        if(moveUfo < 5)
        {
            moveUfo +=.25;
            moveCam +=.12;
            angleCAM +=.2;
        }
    }

    if(( key == 'd' || key == 'D' ) &&!pause )
    {
        if(moveUfo > -5)
        {
            moveUfo -=.25;
            moveCam -=.12;
            angleCAM -=.2;
        }
    }

    if( (key == 's' ||  key == ' ' || key == 'S' ) & !fire )
    {
        fire = true;

        int temp = (96-objectStartPosition)/2;
        collideposition = temp + objectStartPosition+3;

        temp = (96-objectStartPosition2)/2;
        collideposition2 = temp + objectStartPosition2+3;

        temp = (96-objectStartPosition3)/2;
        collideposition3 = temp + objectStartPosition3+3;
    }

    if( key == 'w' ||key == 'W' )
    {

    }

    if( key == 'x' || key == 'X')
    {
        if(viewCam !=180)
            viewCam = 180;
        else viewCam = 0;
    }

    if( key == 'r' || key == 'R' )
    {
        viewCam = 0;
        angleCAM = 0;
    }

    if( key == 'p' || key == 'P')
    {
        if(!pause)
            pause = true;
        else pause = false;
    }

     if( key == '+' && speed1 > 5)
    {
        speed1 -=2;
    }

    if( key == '-' && speed1 < 100)
    {
        speed1 +=2;
    }


    if( key == 'o' || key == 'O' )
    {
        if(rotateON)
        {
            rotateON = false;

            if(left1)
            {
                left1 = false;
            }
            else
            {
                left1 = true;
            }
        }
        else
        {
            rotateON = true;
        }

    }
    glutPostRedisplay();
}

int main(int argc, char** argv)
{
    //Initialize GLUT
    glutInit(&argc, argv);
    glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB | GLUT_DEPTH);
    glutInitWindowSize(1366, 768);

    //Create the window
    glutCreateWindow("UFO War");
    initRendering();

    pause = true;
    //Set handler functions
    glutDisplayFunc(drawScene);

    glutReshapeFunc(handleResize);

    glutKeyboardFunc(keyboard);

    glutTimerFunc(speed2, update, 0); //Add a timer

    glutMainLoop();


    return 0;
}






