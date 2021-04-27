#include <iostream>
using namespace std;

//const char* vars = "eabcdjklmnopqrstuvwxyz";
const char* vars = "123456789";
int asize = 0;
int num = 0;

void PrintGroup(char* a)
{
    for (int z = 0; z < asize * asize; z++)
    {
        cout << a[z];
        if ((z + 1) % asize == 0)
        {
            cout << endl;
        }
    }
}

bool Solved(char* a)
{
    bool flag = true;
    for (int z = 0; z < asize * asize; z++)
    {
        if (a[z] == '.')
            flag = false;
    }
    return flag;
}

void Recurse(char* a, int index)
{
    int mod = 0;
    bool flag = true;

    if (index == asize * asize && Solved(a))
    {
        num++;
        cout << num << endl;
        PrintGroup(a);
        cout << "----------------" << endl;
        delete[] a;
    }

    for (int z = index; z < asize * asize; z++)
    {
        mod = z % asize;
        if (a[z] == '.')
        {
            for (int t = 0; t < asize; t++)
            {
                flag = true;

                //Rows
                /*
                for (int zed = 1; zed <= mod; zed++)  //Optimized
                {
                    if (a[z - zed] == vars[t])
                    {
                        flag = false;
                        break;
                    }
                }*/
                for (int zed = 0; zed < asize; zed++)  //Sudoku
                {
                    if (a[(z-mod) + zed] == vars[t])
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag == false)
                    continue;

                //Columns
                /*
                for (int zed = 0; zed < (z - mod) / asize; zed++)  //Optimized
                {
                    if (a[zed * asize + mod] == vars[t])
                    {
                        flag = false;
                        break;
                    }
                }*/
                for (int zed = 0; zed < asize; zed++)  //Sudoku
                {
                    if (a[zed * asize + mod] == vars[t])
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    char* tt = new char[asize * asize];
                    for (int zed = 0; zed < asize * asize; zed++)
                    {
                        tt[zed] = a[zed];
                    }
                    tt[z] = vars[t];
                    Recurse(tt, z + 1);
                }
            }
            if (flag == 0)
            {
                delete[] a;
                break;
            }
        }
    }
}

char * CreateGroup()
{
    static char* arr = new char[asize*asize];
    int c = asize;

    for (int z = 0; z < asize; z++)
    {
        //vars = "eabcdjklmnopqrstuvwxyz";
        arr[z] = vars[z];
    }
    for (int z = 1; z < asize; z++)
    {
        for (int zed = 0; zed < asize; zed++)
        {
            if (c % asize == 0)
            {
                arr[c] = vars[z];
            }
            else
            {
                arr[c] = '.';
            }
            c++;
        }
    }

    return arr;
}

int main()
{
    char* arr;
    asize = 4;
    //arr = new char[81] { '.', vars[3], '.', vars[7], '.', vars[4], vars[1], '.', '.', '.', vars[1], '.', '.', vars[3], '.', '.', vars[4], '.', vars[4], '.', '.', '.', '.', '.', '.', '.', vars[3], '.', vars[8], '.', '.', '.', vars[2], vars[0], vars[1], '.', vars[0], '.', vars[5], '.', vars[6], vars[7], '.', '.', vars[2], vars[2], vars[6], '.', vars[8], '.', vars[3], '.', vars[7], '.', '.', '.', '.', '.', '.', vars[5], vars[6], '.', '.', '.', '.', vars[7], vars[2], vars[4], vars[8], '.', vars[0], '.', '.', vars[0], vars[8], '.', '.', vars[6], vars[5], '.', '.' };
    arr = CreateGroup();
    Recurse(arr, 0);
}
