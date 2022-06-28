import React , {useEffect , useState} from 'react'
import { useParams } from 'react-router-dom';
import axios from 'axios';
import Button from '@mui/material/Button';
import "./MovieDetail.css"
import Carousel from "../../Components/Carousel/Carousel"
import {
    img_500,
    unavailable,
    unavailableLandscape,
  } from "../../config/config";
import YouTubeIcon from '@mui/icons-material/YouTube';
import Constants from '../../Utilities/Constants'

const MovieDetail = () => {
    const params = useParams()
    const id = params.id
    const media_type = params.mediaType
    const [movies , setMovies] = useState([])
    const [video, setVideo] = useState();

    const fetchData = async () => {

      const url = Constants.API_URL_GET_MOVIE_BY_ID + id
      await axios.get(url)
                  .then((response) => {
                      if(response.data.error ===  null){
                          setMovies(response.data.data)
                    }
                  })
    };
    
    useEffect(() => {
        fetchData();
      }, []);


    return (
        <div>
          {movies && (
            <div className="paperModal">
              <div className="ContentModal">
                <img src={ movies.imageLgUrl ? `${movies.imageLgUrl}` : unavailable } alt={movies.name} className="ContentModal__portrait" />
                <div className="ContentModal__about">
                  <span className="ContentModal__title">
                    {`${movies.name} (${movies.date})`} 
                  </span>
                  {
                      movies.director && 
                      <i className="tagline">by {movies.director.fullname}</i>
                  }
                  <span className="ContentModal__description"> {movies.description} </span>
                  <div>
                    <Carousel id={id}  /> 
                  </div>
                  <Button
                    variant="contained"
                    startIcon={<YouTubeIcon />}
                    color="secondary"
                    target="__blank"
                    href={`https://www.youtube.com/results?search_query=${movies.name} trailer`}
                  > 
                      Watch the Trailer
                  </Button>
                </div>
              </div>
            </div>
          )}
        </div>
    )
}

export default MovieDetail
