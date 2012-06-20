/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package Main;

import java.util.Scanner;

/**
 *
 * @author Gracius
 * this is a half-scored solution
 */
public class Main {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Scanner sc = new Scanner(System.in);
        int T = sc.nextInt();
        while(T-->0) {
            int a = sc.nextInt();
            int b = sc.nextInt();
            System.out.println((int)Math.pow((double)a,(double)b));
        }
    }
}
