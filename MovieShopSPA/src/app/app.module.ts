import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import{HttpClientModule } from'@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { MovieCardComponent } from './shared/components/movie-card/movie-card.component';
import { RegisterComponent } from './auth/register/register.component';
import { PurchasesComponent } from './user/purchases/purchases.component';
import { FavouritesComponent } from './user/favourites/favourites.component';
import { ProfileComponent } from './user/profile/profile.component';
import { ReviewsComponent } from './user/reviews/reviews.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { MovieListComponent } from './movies/movie-list/movie-list.component';
import { LoginComponent } from './auth/login/login.component';
import { CreateCastComponent } from './admin/create-cast/create-cast.component';
import { CreateMovieComponent } from './admin/create-movie/create-movie.component';
import { UpdateMovieComponent } from './admin/update-movie/update-movie.component';
import { GenresComponent } from './genres/genres.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { FooterComponent } from './core/layout/footer/footer.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    PurchasesComponent,
    FavouritesComponent,
    ProfileComponent,
    MovieCardComponent,
    ReviewsComponent,
    MovieDetailsComponent,
    MovieListComponent,
    HomeComponent,
    LoginComponent,
    CreateCastComponent,
    CreateMovieComponent,
    UpdateMovieComponent,
    GenresComponent,
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
