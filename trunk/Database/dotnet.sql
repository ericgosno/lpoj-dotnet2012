/*==============================================================*/
/* DBMS name:      MySQL 5.0                                    */
/* Created on:     3/20/2012 5:27:17 PM                         */
/*==============================================================*/


drop table if exists LPOJ_CLARIFICATION;

drop table if exists LPOJ_CONTEST;

drop table if exists LPOJ_CONTESTANT;

drop table if exists LPOJ_NCPROBLEM;

drop table if exists LPOJ_NCSUBMISSION;

drop table if exists LPOJ_NCTESTCASE;

drop table if exists LPOJ_NCVERDICT;

drop table if exists LPOJ_PROBLEM;

drop table if exists LPOJ_SUBMISSION;

drop table if exists LPOJ_TESTCASE;

drop table if exists LPOJ_USERS;

drop table if exists LPOJ_VERDICT;

/*==============================================================*/
/* Table: LPOJ_CLARIFICATION                                    */
/*==============================================================*/
create table LPOJ_CLARIFICATION
(
   CLARIFICATION_ID     int not null,
   CONTEST_ID           int not null,
   CONTESTANT_ID        int not null,
   CLARIFICATION_TITLE  varchar(50) not null,
   CLARIFICATION_DESCRIPTION text not null,
   CLARIFICATION_ANSWER text not null,
   CLARIFICATION_STATUS int not null,
   primary key (CLARIFICATION_ID)
);

/*==============================================================*/
/* Table: LPOJ_CONTEST                                          */
/*==============================================================*/
create table LPOJ_CONTEST
(
   CONTEST_ID           int not null,
   CONTEST_TITLE        varchar(25) not null,
   CONTEST_DESCRIPTION  varchar(200) not null,
   CONTEST_CREATE       datetime not null,
   CONTEST_BEGIN        datetime not null,
   CONTEST_END          datetime not null,
   CONTEST_FREEZE       datetime not null,
   primary key (CONTEST_ID)
);

/*==============================================================*/
/* Table: LPOJ_CONTESTANT                                       */
/*==============================================================*/
create table LPOJ_CONTESTANT
(
   CONTESTANT_ID        int not null,
   USERS_ID             int not null,
   CONTEST_ID           int not null,
   CONTESTANT_STATUS    int not null,
   primary key (CONTESTANT_ID)
);

/*==============================================================*/
/* Table: LPOJ_NCPROBLEM                                        */
/*==============================================================*/
create table LPOJ_NCPROBLEM
(
   NCPROBLEM_ID         int not null,
   NCPROBLEM_TITLE      varchar(25) not null,
   NCPROBLEM_DESCRIPTION text not null,
   NCPROBLEM_CREATETIME datetime not null,
   NCPROBLEM_STATUS     int not null,
   NCPROBLEM_TIMELIMIT  int not null,
   NCPROBLEM_MEMORYLIMIT int not null,
   primary key (NCPROBLEM_ID)
);

/*==============================================================*/
/* Table: LPOJ_NCSUBMISSION                                     */
/*==============================================================*/
create table LPOJ_NCSUBMISSION
(
   USERS_ID             int not null,
   NCPROBLEM_ID         int not null,
   NCSUBMISSION_SCORE   int not null,
   NCSUBMISSION_TIME    int not null,
   primary key (USERS_ID, NCPROBLEM_ID)
);

/*==============================================================*/
/* Table: LPOJ_NCTESTCASE                                       */
/*==============================================================*/
create table LPOJ_NCTESTCASE
(
   NCTESTCASE_ID        int not null,
   NCPROBLEM_ID         int not null,
   NCTESTCASE_INPUT     varchar(100) not null,
   NCTESTCASE_OUTPUT    varchar(100) not null,
   primary key (NCTESTCASE_ID)
);

/*==============================================================*/
/* Table: LPOJ_NCVERDICT                                        */
/*==============================================================*/
create table LPOJ_NCVERDICT
(
   USERS_ID             int not null,
   NCPROBLEM_ID         int not null,
   NCTESTCASE_ID        int not null,
   NCVERDICT_STATUS     int not null,
   primary key (USERS_ID, NCPROBLEM_ID, NCTESTCASE_ID)
);

/*==============================================================*/
/* Table: LPOJ_PROBLEM                                          */
/*==============================================================*/
create table LPOJ_PROBLEM
(
   PROBLEM_ID           int not null,
   CONTEST_ID           int,
   PROBLEM_TITLE        varchar(25) not null,
   PROBLEM_DESCRIPTION  text not null,
   PROBLEM_CREATETIME   datetime not null,
   PROBLEM_STATUS       int not null,
   PROBLEM_TIMELIMIT    int not null,
   PROBLEM_MEMORYLIMIT  int not null,
   primary key (PROBLEM_ID)
);

/*==============================================================*/
/* Table: LPOJ_SUBMISSION                                       */
/*==============================================================*/
create table LPOJ_SUBMISSION
(
   PROBLEM_ID           int not null,
   CONTESTANT_ID        int not null,
   SUBMISSION_SCORE     int not null,
   SUBMISSION_TIME      int not null,
   primary key (PROBLEM_ID, CONTESTANT_ID)
);

/*==============================================================*/
/* Table: LPOJ_TESTCASE                                         */
/*==============================================================*/
create table LPOJ_TESTCASE
(
   TESTCASE_ID          int not null,
   PROBLEM_ID           int not null,
   TESTCASE_INPUT       varchar(100) not null,
   TESTCASE_OUTPUT      varchar(100) not null,
   primary key (TESTCASE_ID)
);

/*==============================================================*/
/* Table: LPOJ_USERS                                            */
/*==============================================================*/
create table LPOJ_USERS
(
   USERS_ID             int not null,
   USERS_USERNAME       varchar(15) not null,
   USERS_PASSWORD       varchar(35) not null,
   USERS_STATUS         int not null,
   USERS_JOIN_DATE      date not null,
   primary key (USERS_ID)
);

/*==============================================================*/
/* Table: LPOJ_VERDICT                                          */
/*==============================================================*/
create table LPOJ_VERDICT
(
   PROBLEM_ID           int not null,
   CONTESTANT_ID        int not null,
   TESTCASE_ID          int not null,
   VERDICT_STATUS       int not null,
   primary key (PROBLEM_ID, CONTESTANT_ID, TESTCASE_ID)
);

alter table LPOJ_CLARIFICATION add constraint FK_RELATIONSHIP_10 foreign key (CONTESTANT_ID)
      references LPOJ_CONTESTANT (CONTESTANT_ID) on delete restrict on update restrict;

alter table LPOJ_CLARIFICATION add constraint FK_RELATIONSHIP_11 foreign key (CONTEST_ID)
      references LPOJ_CONTEST (CONTEST_ID) on delete restrict on update restrict;

alter table LPOJ_CONTESTANT add constraint FK_RELATIONSHIP_1 foreign key (USERS_ID)
      references LPOJ_USERS (USERS_ID) on delete restrict on update restrict;

alter table LPOJ_CONTESTANT add constraint FK_RELATIONSHIP_2 foreign key (CONTEST_ID)
      references LPOJ_CONTEST (CONTEST_ID) on delete restrict on update restrict;

alter table LPOJ_NCSUBMISSION add constraint FK_RELATIONSHIP_7 foreign key (USERS_ID)
      references LPOJ_USERS (USERS_ID) on delete restrict on update restrict;

alter table LPOJ_NCSUBMISSION add constraint FK_RELATIONSHIP_8 foreign key (NCPROBLEM_ID)
      references LPOJ_NCPROBLEM (NCPROBLEM_ID) on delete restrict on update restrict;

alter table LPOJ_NCTESTCASE add constraint FK_RELATIONSHIP_9 foreign key (NCPROBLEM_ID)
      references LPOJ_NCPROBLEM (NCPROBLEM_ID) on delete restrict on update restrict;

alter table LPOJ_NCVERDICT add constraint FK_RELATIONSHIP_14 foreign key (NCTESTCASE_ID)
      references LPOJ_NCTESTCASE (NCTESTCASE_ID) on delete restrict on update restrict;

alter table LPOJ_NCVERDICT add constraint FK_RELATIONSHIP_15 foreign key (USERS_ID, NCPROBLEM_ID)
      references LPOJ_NCSUBMISSION (USERS_ID, NCPROBLEM_ID) on delete restrict on update restrict;

alter table LPOJ_PROBLEM add constraint FK_RELATIONSHIP_3 foreign key (CONTEST_ID)
      references LPOJ_CONTEST (CONTEST_ID) on delete restrict on update restrict;

alter table LPOJ_SUBMISSION add constraint FK_RELATIONSHIP_4 foreign key (PROBLEM_ID)
      references LPOJ_PROBLEM (PROBLEM_ID) on delete restrict on update restrict;

alter table LPOJ_SUBMISSION add constraint FK_RELATIONSHIP_5 foreign key (CONTESTANT_ID)
      references LPOJ_CONTESTANT (CONTESTANT_ID) on delete restrict on update restrict;

alter table LPOJ_TESTCASE add constraint FK_RELATIONSHIP_6 foreign key (PROBLEM_ID)
      references LPOJ_PROBLEM (PROBLEM_ID) on delete restrict on update restrict;

alter table LPOJ_VERDICT add constraint FK_RELATIONSHIP_12 foreign key (PROBLEM_ID, CONTESTANT_ID)
      references LPOJ_SUBMISSION (PROBLEM_ID, CONTESTANT_ID) on delete restrict on update restrict;

alter table LPOJ_VERDICT add constraint FK_RELATIONSHIP_13 foreign key (TESTCASE_ID)
      references LPOJ_TESTCASE (TESTCASE_ID) on delete restrict on update restrict;

