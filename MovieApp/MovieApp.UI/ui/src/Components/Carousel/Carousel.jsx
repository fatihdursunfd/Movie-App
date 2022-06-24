import axios from "axios";
import React, { useEffect, useState } from "react";
import AliceCarousel from "react-alice-carousel";
import "react-alice-carousel/lib/alice-carousel.css";
import { img_300, noPicture } from "../../config/config";
import "./Carousel.css";
import Constants from "../../Utilities/Constants";

const handleDragStart = (e) => e.preventDefault();

const Gallery = ({ id }) => {

  const [credits, setCredits] = useState([]);
  const [stars, setStars] = useState([]);

  const items = stars.map((c) => (
    <div className="carouselItem">
      <img
        //src={c.imageUrl ? `${c.imageUrl}` : noPicture}
        src = {noPicture}
        alt={c.name}
        onDragStart={handleDragStart}
        className="carouselItem__img"
      />
      <b className="carouselItem__txt">{c?.name}</b>
    </div>
  ));

  const responsive = {
    0: {
      items: 3,
    },
    512: {
      items: 5,
    },
    1024: {
      items: 7,
    },
  };

  const fetchCredits = async () => {
    const url = Constants.API_URL_GET_STARS_BY_MOVIE_ID + id
      await axios.get(url)
                  .then((response) => {
                      if(response.data.error ===  null){
                          console.log(response.data.data);
                          setStars(response.data.data)
                    }
                  })
  };

  useEffect(() => {
    fetchCredits();
  }, []);

  return (
    
    <AliceCarousel
      mouseTracking
      infinite
      disableDotsControls
      disableButtonsControls
      responsive={responsive}
      items={items}
    />
  );
};

export default Gallery;