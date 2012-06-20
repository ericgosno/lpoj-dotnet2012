#include<stdio.h>
#define MOD 1000

int pangkat(int A, int B)
{
    if(B==0) return 1;
    if(B==1) return A%MOD;
    if(B==2) return ((A%MOD)*(A%MOD))%MOD;
    if(B&1) return ((A%MOD)*(pangkat((pangkat(A,B/2)%MOD),2)%MOD))%MOD;
    return (pangkat((pangkat(A,B/2)%MOD),2)%MOD);
}

int main()
{
    int T,a,b;
    scanf("%d",&T);
    while(T--)
    {
        scanf("%d%d",&a,b);
        printf("%d\n",pangkat(a,b));
    }
    return 0;
}
