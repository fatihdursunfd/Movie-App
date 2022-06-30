import React , {useEffect , useState, useContext} from 'react'
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
import Rate from '../../Components/Rate/Rate';
import { Context } from '../../Context/Context';

const MovieDetail = () => {

    const { user } = useContext(Context);

    const params = useParams()
    const id = params.id
    const media_type = params.mediaType
    const [movie , setMovie] = useState([])
    const [rating, setRating] = useState(0);

    const fetchData = async () => {

      const url = Constants.API_URL_GET_MOVIE_BY_ID + id
      await axios.get(url)
                  .then((response) => {
                      if(response.data.error ===  null){
                          setMovie(response.data.data)
                    }
                  })
    };
    
    useEffect(() => {
        fetchData();
      }, []);


    return (
        <div>
          {movie && (
            <div className="paperModal">
              <div className="ContentModal">
                <img src={ movie.imageLgUrl ? `${movie.imageLgUrl}` : unavailable } alt={movie.name} className="ContentModal__portrait" />
                <div className="ContentModal__about">
                  <span className="ContentModal__title">
                    {`${movie.name} (${movie.date})`} 
                  </span>
                  {
                      movie.director && 
                      <i className="tagline">by {movie.director.fullname}</i>
                  }
                  {
                      movie.minute && 
                      <i className="tagline">{movie.minute }</i>
                  }
                  <span className="ContentModal__description"> {movie.description} </span>
                  <div>
                    <Carousel id={id}  /> 
                  </div>
                  <Button
                    variant="contained"
                    startIcon={<YouTubeIcon />}
                    color="secondary"
                    target="__blank"
                    href={`https://www.youtube.com/results?search_query=${movie.name} trailer`}
                  > 
                      Watch the Trailer
                  </Button>
                  {
                    user &&
                      <>
                        <span className='ContentModal__rate'> Rate This Movie</span>
                        <div className='ContentModal__rating'>
                            < Rate rating={rating} onRating={(rate) => setRating(rate)}/>
                        </div>
                      </>
                  }
                  
                </div>
              </div>
            </div>
          )}
        </div>
    )
}

export default MovieDetail
