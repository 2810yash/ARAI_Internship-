                    <%@ Page Title="" Language="C#" MasterPageFile="~/Home.Master" AutoEventWireup="true" CodeBehind="HomePage2.aspx.cs" Inherits="AdminTemplate3._1._0.HomePage2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
 <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <div class="content-header">
      <div class="container-fluid"> 
        <div class="row mb-2">
          <div class="col-sm-6">
            <h1 class="m-0">Dashboard</h1>
          </div><!-- /.col --> 
          <div class="col-sm-6">
            <ol class="breadcrumb float-sm-right">  
              <li class="breadcrumb-item text-decoration-none"><a href="#">Home</a></li>
              <li class="breadcrumb-item active">Dashboard</li>
            </ol>
          </div><!-- /.col -->
 
        </div><!-- /.row -->
      </div><!-- /.container-fluid -->
    </div>
      <script src="https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.9.4/Chart.min.js"></script>

    <!-- /.content-header -->

    <!-- Main content -->
    <section class="content">
      <div class="container-fluid">
        <!-- Small boxes (Stat box) -->
        <div class="row">
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-info">
              <div class="inner">
                <h3><sup style="font-size: 25px"><asp:Label ID ="lblCurrentMonthPermitCount" runat="server"></asp:Label></sup></h3>

                <p>Work Permits This Month</p>
              </div>
              <div class="icon">
                <i class="ion ion-pie-graph"></i>
              </div>
                <!-- Link to the View Permits page here-->
              <a href="viewWorkPermit.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-success">
              <div class="inner">
                <h3><sup style="font-size: 25px"><asp:Label ID ="lblTotalPermitCount" runat="server"></asp:Label> </sup></h3>

                <p> Total Work Permits</p>
              </div>
              <div class="icon">
                <i class="ion ion-stats-bars"></i>
              </div>
              <a href="viewWorkPermit.aspx" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-warning">
              <div class="inner">
                <h3>440</h3>

                <p>User Registrations</p>
              </div>
              <div class="icon">
                <i class="ion ion-person-add"></i>
              </div>
              <a href="#" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <!-- ./col -->
          <div class="col-lg-3 col-6">
            <!-- small box -->
            <div class="small-box bg-danger">
              <div class="inner">
                <h3>650</h3>

                <p>Unique Visitors</p>
              </div>
              <div class="icon">
                <i class="ion ion-pie-graph"></i>
              </div>
              <a href="#" class="small-box-footer">More info <i class="fas fa-arrow-circle-right"></i></a>
            </div>
          </div>
          <!-- ./col -->
        </div>
        <!-- /.row -->
        <!-- Main row -->
        <div class="row">
          <!-- Left col -->
          <section class="col-lg-7 connectedSortable">
            <!-- Custom tabs (Charts with tabs)-->
            <div class="card">
              <div class="card-header">
                <h3 class="card-title">
                  <i class="fas fa-chart-bar mr-1"></i>
                  Work Permit Details
                </h3>
                <div class="card-tools">
                  <ul class="nav nav-pills ml-auto">
                    <li class="nav-item">
                      <a class="nav-link active" href="#permit-chart1" data-toggle="tab">Permits Issued</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link" href="#permit-chart2" data-toggle="tab">Distribution</a>
                    </li>
                  </ul>
                </div>
              </div><!-- /.card-header -->
              <div class="card-body">
                <div class="tab-content p-0">
                  <div class="chart tab-pane active" id="permit-chart1"
                       style="position: relative; height: 500px;">
                      <canvas id="workPermitChart1" width="600" height="400"></canvas>
                      <asp:HiddenField ID="hfChartData1" runat="server" />
                   </div>
                    <div class="chart tab-pane active" id="permit-chart2"
                       style="position: relative; height: 500px;">
                      <canvas id="workPermitChart2" width="600" height="300"></canvas>
                      
                   </div>
                </div>
              </div><!-- /.card-body -->
            </div>
            <!-- /.card -->

          </section>
          <!-- /.Left col -->
          <!-- right col (We are only adding the ID to make the widgets sortable)-->
          <section class="col-lg-5 connectedSortable">

            <!-- Map card -->

            <div class="card bg-white">
              <div class="card-header border-0">
                <h3 class="card-title">
                  <i class="fas fa-chart-pie mr-1"></i>
                  Department Wise Issues
                </h3>
                <!-- card tools -->
                <div class="card-tools">
                  <button type="button" class="btn btn-primary btn-sm" data-card-widget="collapse" title="Collapse">
                    <i class="fas fa-minus"></i>
                  </button>
                </div>  
                <!-- /.card-tools -->
              </div>
                <div class="card-body">
                  <canvas id="deptPieChart" width="600" height="300"></canvas>
                  <asp:HiddenField ID="piechart" runat="server" />

              </div>
              <!-- /.card-body-->
            </div>
            <!-- /.card -->

            <!-- Calendar -->
            <div class="card bg-white">
              <div class="card-header border-0">
                <h3 class="card-title">
                  <i class="fas fa-chart-pie mr-1"></i>
                  Site Wise Issues
                </h3>
                <!-- card tools -->
                <div class="card-tools">
                  <button type="button" class="btn btn-primary btn-sm" data-card-widget="collapse" title="Collapse">
                    <i class="fas fa-minus"></i>
                  </button>
                </div>  
                <!-- /.card-tools -->
              </div>
                <div class="card-body">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:strconn %>" SelectCommand="dbo.usp_GetSiteDistribution" SelectCommandType="StoredProcedure"></asp:SqlDataSource>
                  <canvas id="sitePieChart" width="600" height="300"></canvas>
                  <asp:HiddenField ID="siteChart" runat="server" />
              </div>
              <!-- /.card-body-->
            </div>
            <!-- /.card -->
          </section>
          <!-- right col -->
        </div>
        <!-- /.row (main row) -->
      </div><!-- /.container-fluid -->
    </section>
    <!-- /.content -->
  </div>

    <script>
        window.onload = function () {
            var chartData1 = JSON.parse(document.getElementById('<%= hfChartData1.ClientID %>').value);
            var ctx = document.getElementById('workPermitChart1').getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: chartData1.labels,
                    datasets: [{
                        label: 'Number of Work Permits Issued',
                        data: chartData1.data,
                        backgroundColor: 'rgba(75, 192, 192, 0.2)',
                        borderColor: 'rgba(75, 192, 192, 1)',
                        borderWidth: 1
                    }]
                },
                options: {
                    scales: {
                        yAxes: [{
                            ticks: {
                                beginAtZero: true
                            }
                        }]
                    }
                }
            });

            var chartData2 = JSON.parse(document.getElementById('<%= hfChartData1.ClientID %>').value);
            var ctx2 = document.getElementById('workPermitChart2').getContext('2d');
            var myChart2 = new Chart(ctx2, {
                type: 'pie',
                data: {
                    labels: chartData2.labels,
                    datasets: [{
                        label: 'Permit Distribution',
                        data: chartData2.data,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'Work Permit Distribution by Month'
                    }
                }
            });

            var chartData3 = JSON.parse(document.getElementById('<%= piechart.ClientID %>').value);
            var ctx3 = document.getElementById('deptPieChart').getContext('2d');
            var myChart3 = new Chart(ctx3, {
                type: 'pie',
                data: {
                    labels: chartData3.labels,
                    datasets: [{
                        label: 'Department Distribution',
                        data: chartData3.data,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'Work Permit Distribution by Department'
                    }
                }
            });

             var chartData4 = JSON.parse(document.getElementById('<%= siteChart.ClientID %>').value);
            var ctx4 = document.getElementById('sitePieChart').getContext('2d');
            var myChart4 = new Chart(ctx4, {
                type: 'pie',
                data: {
                    labels: chartData4.labels,
                    datasets: [{
                        label: 'Department Distribution',
                        data: chartData4.data,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.2)',
                            'rgba(54, 162, 235, 0.2)',
                            'rgba(255, 206, 86, 0.2)',
                            'rgba(75, 192, 192, 0.2)',
                            'rgba(153, 102, 255, 0.2)',
                            'rgba(255, 159, 64, 0.2)'
                        ],
                        borderColor: [
                            'rgba(255, 99, 132, 1)',
                            'rgba(54, 162, 235, 1)',
                            'rgba(255, 206, 86, 1)',
                            'rgba(75, 192, 192, 1)',
                            'rgba(153, 102, 255, 1)',
                            'rgba(255, 159, 64, 1)'
                        ],
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    legend: {
                        position: 'top',
                    },
                    title: {
                        display: true,
                        text: 'Work Permit Distribution by Site'
                    }
                }
            });
        };
    </script>
     
    <script>
        window.onload = function1() {
            
        };
    </script>
  <!-- /.content-wrapper -->
</asp:Content>