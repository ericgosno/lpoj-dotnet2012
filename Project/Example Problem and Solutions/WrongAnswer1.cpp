#include<stdio.h>
#include<math.h>
#define MOD 1000

int main()
{
    int T,a,b;
    scanf("%d",&T);
    while(T--)
    {
        scanf("%d%d",&a,&b);
        printf("%d\n",(int)round(pow((double)a,(double)b))%MOD);
    }
    return 0;
}
