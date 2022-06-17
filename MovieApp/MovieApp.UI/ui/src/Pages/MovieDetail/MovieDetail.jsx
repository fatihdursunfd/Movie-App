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

const MovieDetail = () => {
    const params = useParams()
    const id = params.id
    const media_type = params.mediaType

    const [content, setContent] = useState([]);
    const [video, setVideo] = useState();

    const fetchData = async () => {
      const url = `https://api.themoviedb.org/3/${media_type}/${id}?api_key=44f4b50a7a7b8ece939348ff65ba06f3&language=en-US`
      const { data } = await axios.get(url);
      setContent(data);
    };
    
    const fetchVideo = async () => {
        const url = `https://api.themoviedb.org/3/${media_type}/${id}/videos?api_key=44f4b50a7a7b8ece939348ff65ba06f3&language=en-US`
        const { data } = await axios.get(url);
        setVideo(data.results[0]?.key);
    };

    useEffect(() => {
        fetchData();
        fetchVideo();
      }, []);


    return (
        <div>
          {content && (
            <div className="paperModal">
              <div className="ContentModal">
                <img src={ content.poster_path ? `${img_500}/${content.poster_path}` : unavailable } alt={content.name || content.title} className="ContentModal__portrait" />
                <img src={ content.backdrop_path ? `${img_500}/${content.backdrop_path}` : unavailableLandscape } alt={content.name || content.title}  className="ContentModal__landscape" />
                <div className="ContentModal__about">
                  <span className="ContentModal__title">
                    {content.name || content.title} (
                    {(
                      content.first_air_date ||
                      content.release_date ||
                      "-----"
                    ).substring(0, 4)}
                    )
                  </span>
                  {content.tagline && (
                    <i className="tagline">{content.tagline}</i>
                  )}

                  <span className="ContentModal__description">
                    {content.overview}
                  </span>

                  <div>
                    <Carousel id={id} media_type={media_type} /> 
                  </div>

                  <Button
                    variant="contained"
                    startIcon={<YouTubeIcon />}
                    color="secondary"
                    target="__blank"
                    href={`https://www.youtube.com/watch?v=${video}`}
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
