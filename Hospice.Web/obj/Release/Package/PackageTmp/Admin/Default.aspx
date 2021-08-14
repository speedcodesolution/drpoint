﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/SiteAdmin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Hospice.Web.Admin.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Page header start -->
				<div class="page-header">
					<ol class="breadcrumb">
						<li class="breadcrumb-item active">Hospital Dashboard</li>
					</ol>
					<%--<div class="contact">
						<img src="../Assests/img/contact.svg" alt="Contact" />
						<div class="details">
							<div class="info">Emergency number</div>
							<div class="contact-number">1234 1234 0000</div>
						</div>
					</div>--%>
				</div>
				<!-- Page header end -->


				<!-- Content wrapper start -->
				<div class="content-wrapper">

					<!-- Row start -->
					<div class="row gutters">
						<div class="col-xl-2 col-lg-2 col-md-4 col-sm-4 col-12">
							<div class="hospital-tiles">
								<img src="../Assests/img/hospital/appointment.svg" alt="Appointments" />
								<p>Appointments</p>
								<h2>49</h2>
							</div>
						</div>
						<div class="col-xl-2 col-lg-2 col-md-4 col-sm-4 col-12">
							<div class="hospital-tiles">
								<img src="../Assests/img/hospital/patient.svg" alt="Patients">
								<p>New Patients</p>
								<h2>60</h2>
							</div>
						</div>
						<div class="col-xl-2 col-lg-2 col-md-4 col-sm-4 col-12">
							<div class="hospital-tiles">
								<img src="../Assests/img/hospital/operation.svg" alt="Operations" />
								<p>Operations</p>
								<h2>21</h2>
							</div>
						</div>
						<div class="col-xl-2 col-lg-2 col-md-4 col-sm-4 col-12">
                            <a href="DoctorListing" title="Doctor">
							<div class="hospital-tiles">
								<img src="../Assests/img/hospital/doctor.svg" alt="Doctors" />
								<p>Doctors</p>
								<h2 id="doctorcount" runat="server">75</h2>
							</div></a>
						</div>
						<div class="col-xl-2 col-lg-2 col-md-4 col-sm-4 col-12">
							<div class="hospital-tiles">
								<img src="../Assests/img/hospital/staff.svg" alt="Staff" />
								<p>Staff</p>
								<h2>253</h2>
							</div>
						</div>
						<div class="col-xl-2 col-lg-2 col-md-4 col-sm-4 col-12">
							<div class="hospital-tiles violet">
								<img src="../Assests/img/hospital/revenue.svg" alt="Earnings" />
								<p>Earnings</p>
								<h2>$900k</h2>
							</div>
						</div>
					</div>
					<!-- Row end -->

					<!-- Row start -->
					<div class="row gutters">
						<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-xs-12">
							<div class="card">
								<div class="card-header">
									<div class="card-title">Patients</div>
								</div>
								<div class="card-body">
									<div id="hospital-line-column-graph"></div>
								</div>
							</div>
						</div>
						<div class="col-xl-6 col-lg-6 col-md-12 col-sm-12 col-xs-12">
							<div class="card">
								<div class="card-header">
									<div class="card-title">Treatment Type</div>
								</div>
								<div class="card-body">
									<div id="hospital-line-area-graph"></div>
								</div>
							</div>
						</div>
					</div>
					<!-- Row end -->

					<!-- Row start -->
					<div class="row gutters">
						<div class="col-xl-12 col-lg-12 col-md-12 col-sm-12 col-xs-12">
							<div class="card">
								<div class="card-header">
									<div class="card-title">Patients by Age</div>
								</div>
								<div class="card-body">
									<div id="hospital-patients-by-age"></div>
								</div>
							</div>
						</div>
					</div>
					<!-- Row end -->

					<!-- Row start -->
					<div class="row gutters">
						<div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-xs-12">
							<div class="card">
								<div class="card-header">
									<div class="card-title">Top Doctors</div>
								</div>
								<div class="card-body">
									<div class="top-doctors-container">
										<div class="top-doctor">
											<img src="../Assests/img/user2.png" class="avatar" alt="Agent">
											<div class="doctor-details">
												<h6>Dr. Clive Williams</h6>
												<div class="doctor-score">
													<div class="progress">
														<div class="progress-bar bg-blue" role="progressbar" style="width: 87%" aria-valuenow="87" aria-valuemin="0" aria-valuemax="100"></div>
													</div>
													<div class="points">
														<div class="left">Rank #1</div>
														<div class="right">9,800 Ratings</div>
													</div>
												</div>
											</div>
										</div>
										<div class="top-doctor">
											<img src="../Assests/img/user3.png" class="avatar" alt="Agent">
											<div class="doctor-details">
												<h6>Dr. Levsmia</h6>
												<div class="doctor-score">
													<div class="progress">
														<div class="progress-bar bg-blue" role="progressbar" style="width: 65%" aria-valuenow="65" aria-valuemin="0" aria-valuemax="100"></div>
													</div>
													<div class="points">
														<div class="left">Rank #2</div>
														<div class="right">7,500 Ratings</div>
													</div>
												</div>
											</div>
										</div>
										<div class="top-doctor">
											<img src="../Assests/img/user14.png" class="avatar" alt="Agent">
											<div class="doctor-details">
												<h6>Dr. Emma George</h6>
												<div class="doctor-score">
													<div class="progress">
														<div class="progress-bar bg-pink" role="progressbar" style="width: 42%" aria-valuenow="42" aria-valuemin="0" aria-valuemax="100"></div>
													</div>
													<div class="points">
														<div class="left">Rank #3</div>
														<div class="right">4,200 Ratings</div>
													</div>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
						<div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-xs-12">
							<div class="card">
								<div class="card-header">
									<div class="card-title">Messages</div>
								</div>
								<div class="card-body">
									<ul class="custom-messages">
										<li class="clearfix">
											<div class="customer">TB</div>
											<div class="delivery-details">
												<span class="badge">Appointment</span>
												<h5>Tom Bartholet</h5>
												<p>Your appointment with Dr. Kelly is confirmed at 04:30 PM and your reference ID is <b>TK556753</b>.</p>
											</div>
										</li>
										<li class="clearfix">
											<div class="customer secondary">DC</div>
											<div class="delivery-details">
												<span class="badge">Cancelled</span>
												<h5>Dale Colorado</h5>
												<p>We are pleased to inform that the following ticket no.<b>TK217887</b> have been cancelled.</p>
											</div>
										</li>
									</ul>
								</div>
							</div>
						</div>
						<div class="col-xl-4 col-lg-4 col-md-12 col-sm-12 col-xs-12">
							<div class="card">
								<div class="card-header">
									<div class="card-title">Overall Ratings</div>
								</div>
								<div class="card-body">
									<div class="hospital-ratings">
										<div class="total-ratings">
											<h2>4.5</h2>
											<div class="rating-stars">
												<div id="rate1"></div>
											</div>
										</div>
										<div class="ratings-list-container">
											<div class="ratings-list">
												<div class="rating-level">5.0</div>
												<div class="rating-stars">
													<div class="rateA"></div>
												</div>
												<div class="total">
													8,500 <span class="percentage">65%</span>
												</div>
											</div>
											<div class="ratings-list">
												<div class="rating-level">4.0</div>
												<div class="rating-stars">
													<div class="rateB"></div>
												</div>
												<div class="total">
													3,500 <span class="percentage">20%</span>
												</div>
											</div>
											<div class="ratings-list">
												<div class="rating-level">3.0</div>
												<div class="rating-stars">
													<div class="rateC"></div>
												</div>
												<div class="total">
													1,400 <span class="percentage">15%</span>
												</div>
											</div>
											<div class="ratings-list">
												<div class="rating-level">2.0</div>
												<div class="rating-stars">
													<div class="rateD"></div>
												</div>
												<div class="total">
													300 <span class="percentage">05%</span>
												</div>
											</div>
											<div class="ratings-list">
												<div class="rating-level">1.0</div>
												<div class="rating-stars">
													<div class="rateE"></div>
												</div>
												<div class="total">
													75 <span class="percentage">03%</span>
												</div>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<!-- Row end -->

				</div>
				<!-- Content wrapper end -->
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderScript" runat="server">
</asp:Content>
